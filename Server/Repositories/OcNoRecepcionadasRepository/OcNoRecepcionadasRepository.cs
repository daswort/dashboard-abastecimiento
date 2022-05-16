using System.Text.Json;

namespace DashboardAbast.Server.Repositories.OcNoRecepcionadasRepository
{
    public class OcNoRecepcionadasRepository : Repository<OcNoRecepcionada>, IOcNoRecepcionadasRepository
    {
        public OcNoRecepcionadasRepository(AxCasinoContext context) : base(context)
        {
        }

        public IQueryable<OcNoRecepcionada> ObtenerOcNoRecepcionadas(OcNoRecepcionadasParametros parametros)
        {
            return (parametros.Familias.Any()) ? ObtenerQueryConFamilia(parametros) : ObtenerQuerySinFamilia(parametros);
        }

        private IQueryable<OcNoRecepcionada> ObtenerQuerySinFamilia(OcNoRecepcionadasParametros parametros)
        {
            IQueryable<OcNoRecepcionada> qr;

            if (parametros.OrdenesCompra.Any())
            {
                qr = (from t1 in AxCasinoContext.Set<Purchtable>().Where(x => parametros.OrdenesCompra.Contains(x.Purchid))
                      join t2 in AxCasinoContext.Set<Purchline>().Where(x => parametros.OrdenesCompra.Contains(x.Purchid)) 
                      on new { t1.Purchid, t1.Dataareaid } equals new { t2.Purchid, t2.Dataareaid }
                      join tt2 in (
                         from tb in AxCasinoContext.Set<Purchline>().Where(y => parametros.OrdenesCompra.Contains(y.Purchid))
                         group tb by new { tb.Purchid } into grp
                         select new { NumOc = grp.Key.Purchid, CantLnOriginal = grp.Sum(t => 1) }
                      ) on t1.Purchid equals tt2.NumOc into can
                      from tt2 in can.DefaultIfEmpty()
                      join t4 in AxCasinoContext.Set<CeDocParaAnalizar>().Where(x => parametros.OrdenesCompra.Contains(x.Oc)) 
                      on t1.Purchid equals t4.Oc into doc
                      from aDoc in doc.DefaultIfEmpty()
                      orderby t1.Purchid, t1.Deliverydate descending
                      select new OcNoRecepcionada()
                      {
                          NumOc = t1.Purchid,
                          FolioFact = aDoc.Folio,
                          //ReferenciasOc = aDoc.Referencias,
                          IdProveedor = t1.Invoiceaccount,
                          DetalleNumOc = t1.Purchid,
                          CodigoProducto = t2.Barcode,
                          //Familia = (t1.PtbFolio.Equals(1) ? "Alimento" : ""),
                          //CosIdfamilia = t1.CosIdfamilia,
                          //TipoCompra = t1.Purchpoolid,
                          Cantidad = t2.Purchqty,
                          Unidad = t2.Purchunit,
                          CentroCosto = t1.Inventlocationid,
                          FechaDespacho = t1.Deliverydate,
                          CantLnOriginal = tt2.CantLnOriginal
                      });
            }
            else
            {
                qr = (from t1 in AxCasinoContext.Set<Purchtable>()
                      .Select(x1 => new { x1.Purchid, x1.Invoiceaccount, x1.Inventlocationid, x1.Deliverydate, x1.Dataareaid })
                      .Where(x1 => x1.Deliverydate >= parametros.FechaIni && x1.Deliverydate <= parametros.FechaFin && x1.Inventlocationid != "0999" && x1.Dataareaid == "cas")
                      join t2 in AxCasinoContext.Set<Purchline>()
                      .Select(x2 => new { x2.Purchid, x2.Barcode, x2.Purchqty, x2.Dataareaid }) 
                      .Where(x2 => x2.Purchqty > 0 && x2.Dataareaid == "cas")
                      on new { t1.Purchid, t1.Dataareaid } equals new { t2.Purchid, t2.Dataareaid }
                      orderby t1.Purchid, t1.Deliverydate descending
                      select new OcNoRecepcionada()
                      {
                          NumOc = t1.Purchid,
                          IdProveedor = t1.Invoiceaccount,
                          CodigoProducto = t2.Barcode,
                          CentroCosto = t1.Inventlocationid
                      });

                if (parametros.CentrosCosto.Any())
                    qr = qr.Where(x => parametros.CentrosCosto.Contains(x.CentroCosto));
                if (parametros.Proveedores.Any())
                    qr = qr.Where(x => parametros.Proveedores.Contains(x.IdProveedor));
            }
            return qr;
        }

        private IQueryable<OcNoRecepcionada> ObtenerQueryConFamilia(OcNoRecepcionadasParametros parametros)
        {
            IQueryable<OcNoRecepcionada> qr;

            if (parametros.OrdenesCompra.Any())
            {
                qr = (from t1 in AxCasinoContext.Set<Purchtable>().Where(x => parametros.OrdenesCompra.Contains(x.Purchid))
                      join t2 in AxCasinoContext.Set<Purchline>().Where(x => parametros.OrdenesCompra.Contains(x.Purchid))
                      on new { t1.Purchid, t1.Dataareaid } equals new { t2.Purchid, t2.Dataareaid }
                      join tt2 in (
                         from tb in AxCasinoContext.Set<Purchline>().Where(y => parametros.OrdenesCompra.Contains(y.Purchid))
                         group tb by new { tb.Purchid } into grp
                         select new { NumOc = grp.Key.Purchid, CantLnOriginal = grp.Sum(t => 1) }
                      ) on t1.Purchid equals tt2.NumOc into can
                      from tt2 in can.DefaultIfEmpty()
                      join t4 in AxCasinoContext.Set<CeDocParaAnalizar>().Where(x => parametros.OrdenesCompra.Contains(x.Oc)) 
                      on t1.Purchid equals t4.Oc into doc
                      from aDoc in doc.DefaultIfEmpty()
                      orderby t1.Purchid, t1.Deliverydate descending
                      select new OcNoRecepcionada()
                      {
                          NumOc = t1.Purchid,
                          FolioFact = aDoc.Folio,
                          //ReferenciasOc = aDoc.Referencias,
                          IdProveedor = t1.Invoiceaccount,
                          DetalleNumOc = t1.Purchid,
                          CodigoProducto = t2.Barcode,
                          //Familia = (t1.PtbFolio.Equals(1) ? "Alimento" : ""),
                          //CosIdfamilia = t1.CosIdfamilia,
                          //TipoCompra = t1.Purchpoolid,
                          Cantidad = t2.Purchqty,
                          Unidad = t2.Purchunit,
                          CentroCosto = t1.Inventlocationid,
                          FechaDespacho = t1.Deliverydate,
                          CantLnOriginal = tt2.CantLnOriginal
                      });
            }
            else
            {
                qr = (from t1 in AxCasinoContext.Set<Purchtable>()
                      .Select(x => new { x.Purchid, x.Invoiceaccount, x.Inventlocationid, x.CosIdfamilia, x.Deliverydate, x.Dataareaid })
                      .Where(x1 => x1.Deliverydate >= parametros.FechaIni && x1.Deliverydate <= parametros.FechaFin && x1.Inventlocationid != "0999" && x1.Dataareaid == "cas")
                      join t2 in AxCasinoContext.Set<Purchline>()
                      .Select(x => new { x.Purchid, x.Barcode, x.Purchqty, x.Dataareaid })
                      .Where(x2 => x2.Purchqty > 0 && x2.Dataareaid == "cas")
                      on new { t1.Purchid, t1.Dataareaid } equals new { t2.Purchid, t2.Dataareaid }
                      where parametros.Familias.Contains(t1.CosIdfamilia)
                      orderby t1.Purchid, t1.Deliverydate descending
                      select new OcNoRecepcionada()
                      {
                          NumOc = t1.Purchid,
                          IdProveedor = t1.Invoiceaccount,
                          CodigoProducto = t2.Barcode,
                          CentroCosto = t1.Inventlocationid
                      });

                if (parametros.CentrosCosto.Any())
                    qr = qr.Where(x => parametros.CentrosCosto.Contains(x.CentroCosto));
                if (parametros.Proveedores.Any())
                    qr = qr.Where(x => parametros.Proveedores.Contains(x.IdProveedor));
            }
            return qr;
        }

        public AxCasinoContext AxCasinoContext
        {
            get { return _dbContext as AxCasinoContext; }
        }
    }
}