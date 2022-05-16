using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using DashboardAbast.Shared.ChartDataModels;
using DashboardAbast.Server.Misc;
using System.Text.Json;
using System.Collections;

namespace DashboardAbast.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly PptoCeContext _pptoCeContext;
        private readonly CerberusMinutaContext _cerberusMinutaContext;
        private readonly AxCasinoContext _axCasinoContext;
        private readonly CerberusContext _cerberusContext;

        public ITblIconstruyeOcPasoRepository Ent1 { get; private set; }
        public IProductoRepository Ent2 { get; private set; }
        public ICentroCostoRepository Ent3 { get; private set; }
        public IProveedorRepository Ent4 { get; private set; }
        public IOcNoRecepcionadasRepository Ent5 { get; private set; }
        public IEjecutivoRepository EjecutivoRepo { get; private set; }
        public IRecepcionFolioRepository RecepcionFolioRepo { get; private set; }

        private UIDespachosDelDia DataSet { get; set; }

        public DashboardController(
            PptoCeContext pptoCeContext,
            CerberusMinutaContext cerberusMinutaContext,
            AxCasinoContext axCasinoContext,
            CerberusContext cerberusContext
        )
        {
            _pptoCeContext = pptoCeContext;
            _cerberusMinutaContext = cerberusMinutaContext;
            _axCasinoContext = axCasinoContext;
            _cerberusContext = cerberusContext;

            Ent1 = new TblIconstruyeOcPasoRepository(_pptoCeContext);
            Ent2 = new ProductoRepository(_cerberusContext);
            Ent3 = new CentroCostoRepository(_cerberusMinutaContext);
            Ent4 = new ProveedorRepository(_pptoCeContext);
            Ent5 = new OcNoRecepcionadasRepository(_axCasinoContext);
            EjecutivoRepo = new EjecutivoRepository(_pptoCeContext);
            RecepcionFolioRepo = new RecepcionFolioRepository(_cerberusContext);

            DataSet = new UIDespachosDelDia();
        }

        private async Task<IEnumerable<string>> GetNumsOCParaPaginacion(OcNoRecepcionadasParametros parametros)
        {
            var queryOcParaDespachar = Ent5.ObtenerOcNoRecepcionadas(parametros);
            var queryTblIConstruye = Ent1.GetOrdenesCompraVigentesByFechaDespacho(parametros);
            var queryOcDespachadas = RecepcionFolioRepo.ObtenerOcRecepcionadas(parametros);

            if (parametros.Ejecutivos.Any()) {
                EjecutivoParametros ejecutivoParametros = new();
                ejecutivoParametros.ListaRut = parametros.Ejecutivos;
                var centrosCostoEjecutivos = await EjecutivoRepo.ObtenerEjecutivos(ejecutivoParametros).AsNoTracking().ToListAsync();
                queryTblIConstruye = queryTblIConstruye.Where(x => centrosCostoEjecutivos.Select(y => y.CentroCosto).Distinct().Contains(x.CentroCosto));
                queryOcParaDespachar = queryOcParaDespachar.Where(x => centrosCostoEjecutivos.Select(y => y.CentroCosto).Distinct().Contains(x.CentroCosto));
                queryOcDespachadas = queryOcDespachadas.Where(x => centrosCostoEjecutivos.Select(y => y.CentroCosto).Distinct().Contains(x.CentroCosto));
            }

            System.Diagnostics.Debug.WriteLine("\n################ INICIO QUERY CONFIRMADAS POR PROVEEDOR");
            var ocParaDespacharFiltradaList = (from noFiltrada in await queryOcParaDespachar.AsNoTracking().ToListAsync()
                                               join filtarda in await queryTblIConstruye.AsNoTracking().ToListAsync() 
                                               on new { noFiltrada.NumOc, noFiltrada.CodigoProducto } equals new { filtarda.NumOc, filtarda.CodigoProducto }
                                               orderby noFiltrada.NumOc, noFiltrada.FechaDespacho descending
                                               select new { noFiltrada.NumOc, noFiltrada.CodigoProducto }).ToList();
            System.Diagnostics.Debug.WriteLine("################ TÉRMINO QUERY CONFIRMADAS POR PROVEEDOR");

            System.Diagnostics.Debug.WriteLine("\n################ INICIO QUERY NO DESPACHADAS");
            var ocLineasNoDEspachadas = (from t1 in ocParaDespacharFiltradaList
                                         join t2 in await queryOcDespachadas.AsNoTracking().ToListAsync() 
                                         on new { t1.NumOc, t1.CodigoProducto } equals new { t2.NumOc, t2.CodigoProducto } into final
                                         from aFinal in final.DefaultIfEmpty()
                                         where aFinal == null
                                         select new { t1.NumOc }).ToList();
            System.Diagnostics.Debug.WriteLine("################ TÉRMINO QUERY NO DESPACHADAS");

            var listaOcs = ocLineasNoDEspachadas.Select(x => x.NumOc).Distinct();

            DataSet.PagesCurr = listaOcs.Skip((parametros.PageNumber - 1) * parametros.PageSize).Take(parametros.PageSize).ToList();

            DataSet.TotalLineas = ocParaDespacharFiltradaList.Count;
            DataSet.TotalLineasPorRecepcionar = ocLineasNoDEspachadas.Count;
            DataSet.TotalLineasRecepcionadas = DataSet.TotalLineas - DataSet.TotalLineasPorRecepcionar;

            DataSet.TotalOc = ocParaDespacharFiltradaList.Select(x => x.NumOc).Distinct().Count();
            DataSet.TotalOcPorRecepcionar = ocLineasNoDEspachadas.Select(x => x.NumOc).Distinct().Count();
            DataSet.TotalOcRecepcionadas = DataSet.TotalOc - DataSet.TotalOcPorRecepcionar;

            DataSet.TotalLineasRecepcionadasPerc = (DataSet.TotalLineas == 0) ? 0 : (int)Math.Round((decimal)DataSet.TotalLineasRecepcionadas / DataSet.TotalLineas * 100);
            DataSet.TotalLineasSinRegistro = 0;

            return DataSet.PagesCurr;
        }

        [HttpGet("despachos")]
        public async Task<ActionResult> GetDespachosDelDia()
        {
            _pptoCeContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _cerberusMinutaContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _axCasinoContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _cerberusContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            List<string> vCentroCosto = Util.ProcessQsCasino(Request.Query["centro-costo"]);
            List<string> vProveedor = Util.ProcessQsProveedor(Request.Query["proveedor"]);
            List<string> vFamilia = Util.ProcessQsFamilia(Request.Query["familia"]);
            List<string> vEjecutivo = Util.ProcessQsEjecutivo(Request.Query["ejecutivo"]);
            DateTime vFechaIni = Util.ProcessQsFecha(Request.Query["fecha-ini"]);
            DateTime vFechaFin = Util.ProcessQsFecha(Request.Query["fecha-fin"]);
            bool vConDetalles = Util.ProcessConDetalles(Request.Query["con-detalles"]);
            string vOrd = Util.ProcessQsOrdenamiento(Request.Query["ord"]);
            int vPageSize = Util.ProcessQsPageSize(Request.Query["page-size"]);
            int vPageNumber = Util.ProcessQsPageNumber(Request.Query["page-number"]);

            OcNoRecepcionadasParametros ocNoRecepcionadasParametros = new();
            ocNoRecepcionadasParametros.FechaIni = vFechaIni;
            ocNoRecepcionadasParametros.FechaFin = vFechaFin;
            ocNoRecepcionadasParametros.CentrosCosto = vCentroCosto;
            ocNoRecepcionadasParametros.Proveedores = vProveedor;
            ocNoRecepcionadasParametros.Ejecutivos = vEjecutivo;
            ocNoRecepcionadasParametros.Familias = vFamilia;
            ocNoRecepcionadasParametros.PageSize = vPageSize;
            ocNoRecepcionadasParametros.PageNumber = vPageNumber;
            ocNoRecepcionadasParametros.Ord = vOrd;

            var numsOcPaginacion = await this.GetNumsOCParaPaginacion(ocNoRecepcionadasParametros);
            ocNoRecepcionadasParametros.OrdenesCompra = numsOcPaginacion.ToList();
 
            System.Diagnostics.Debug.WriteLine("################ DataSet: " + JsonSerializer.Serialize(DataSet, new JsonSerializerOptions() { WriteIndented = true }));

            // Se obtiene todas las líneas hechas por CE
            System.Diagnostics.Debug.WriteLine("\n################ INICIO QUERY OCs PAGINADAS");
            var ocParaDespacharList = await Ent5.ObtenerOcNoRecepcionadas(ocNoRecepcionadasParametros).AsNoTracking().ToListAsync();
            System.Diagnostics.Debug.WriteLine("\n################ TÉRMINO QUERY OCs PAGINADAS");

            // Se obtiene la cantidad de líneas recepcionadas por Oc
            //var ocCantLineasRecepcionadas = (from t1 in ocDespachadasList group t1 by new { t1.NumOc } into grp select new { NumOc = grp.Key.NumOc, CantLnRecibidas = grp.Sum(t => 1) }).ToList();

            // Se obtiene query de los casinos
            CentroCostoParametros centroCostoParametros = new();
            centroCostoParametros.ListaId = ocParaDespacharList.Select(x => x.CentroCosto).Distinct().ToList();
            var casinosQuery = Ent3.ObtenerCentroCostos(centroCostoParametros);

            // Se obtiene lista de los proveedores
            ProveedorParametros proveedorParametros = new();
            proveedorParametros.ListaRut = ocParaDespacharList.Select(x => x.IdProveedor).Distinct().ToList();
            var proveedoresQuery = Ent4.GetProveedoresByListOfIDs(proveedorParametros);

            // Se obtiene lista con los productos
            ProductoParametros productoParametros = new();
            productoParametros.ListaCodigo = ocParaDespacharList.Select(x => x.CodigoProducto).Distinct().ToList();
            var productosQuery = Ent2.GetProductosAll(productoParametros);

            // Se obtiene la lista final con las líneas hechas por CE y que no han sido despachadas aún
            System.Diagnostics.Debug.WriteLine("\n################ INICIO QUERY ocLineasNoDEspachadas");
            var ocLineasNoDEspachadas = (from t1 in ocParaDespacharList
                                         join t3 in await productosQuery.AsNoTracking().ToListAsync() on t1.CodigoProducto equals t3.ArticuloId
                                         join t4 in await casinosQuery.AsNoTracking().ToListAsync() on t1.CentroCosto equals t4.Codigo
                                         join t5 in await proveedoresQuery.AsNoTracking().ToListAsync() on t1.IdProveedor equals t5.ProveedorId
                                         orderby t1.NumOc, t1.FechaDespacho descending
                                         select new QrOrdenCompraLinea
                                         {
                                             NumOc = t1.NumOc,
                                             FolioFact = t1.FolioFact == null ? "Sin factura" : t1.FolioFact.ToString(),
                                             ReferenciasOc = t1.ReferenciasOc,
                                             IdProveedor = t1.IdProveedor,
                                             NombreProveedor = t5.ProveedorAlias,
                                             DetalleNumOc = t1.DetalleNumOc,
                                             CodigoProducto = t1.CodigoProducto,
                                             NombreProducto = t3.ArticuloNameAlias,
                                             //NombreProducto = "Producto de prueba",
                                             TipoCompra = t1.TipoCompra,
                                             Cantidad = t1.Cantidad,
                                             Precio = (decimal)t3.Price,
                                             //Precio = 1000,
                                             Unidad = t1.Unidad,
                                             IdCasino = t1.CentroCosto,
                                             NombreCasino = t4.Nombre,
                                             //NombreCasino = "Casino de prueba",
                                             FechaDespacho = t1.FechaDespacho,
                                             CantLnOriginal = t1.CantLnOriginal,
                                             //CantLnRecepcionadas = (from tb in ocCantLineasRecepcionadas where t1.NumOc == tb.NumOc select tb.CantLnRecibidas).FirstOrDefault()
                                             CantLnRecepcionadas = null
                                         }).ToList();
            System.Diagnostics.Debug.WriteLine("################ TÉRMINO QUERY ocLineasNoDEspachadas");

            DataSet.UIOrdenCompra = Util.AddDetalleToOrdenCompra(ocLineasNoDEspachadas);
            return Ok(DataSet);
        }

        [HttpGet("proveedores")]
        public async Task<ActionResult> GetProveedoresOc()
        {
            DateTime vFechaIni = Util.ProcessQsFecha(Request.Query["fecha-ini"]);
            DateTime vFechaFin = Util.ProcessQsFecha(Request.Query["fecha-fin"]);

            vFechaIni = vFechaIni.AddDays(-5);
            vFechaFin = vFechaFin.AddDays(5);

            var proveedoresAxCasinoList = await (from t1 in _axCasinoContext.Set<Purchtable>()
                                                 where t1.Deliverydate >= vFechaIni && t1.Deliverydate <= vFechaFin
                                                 select new { ProveedorId = t1.Invoiceaccount }).Distinct().AsNoTracking().ToListAsync();

            var proveedoresAllList = await (from t1 in _pptoCeContext.Set<TblProveedore>() select new { t1.ProveedorId, t1.ProveedorAlias }).AsNoTracking().ToListAsync();

            var proveedoresPorOcFechasList = (from t1 in proveedoresAxCasinoList
                                              join t2 in proveedoresAllList on t1.ProveedorId equals t2.ProveedorId
                                              select new
                                              {
                                                  t2.ProveedorId,
                                                  t2.ProveedorAlias
                                              }).ToList();
            return Ok(proveedoresPorOcFechasList);
        }
    }
}