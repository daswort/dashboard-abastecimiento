using System.Text.Json;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

namespace DashboardAbast.Server.Misc
{
    public static class Util
    {
        public static void PrintList(IEnumerable<object> lista)
        {
            System.Diagnostics.Debug.WriteLine("#################################################################################################");
            System.Diagnostics.Debug.WriteLine("################ Lista: " + JsonSerializer.Serialize(lista, new JsonSerializerOptions() { WriteIndented = true }));
            System.Diagnostics.Debug.WriteLine("#################################################################################################");
        }

        public static int ProcessQsPageSize(string qsPageSize)
        {
            if (qsPageSize == null) return 5;
            if (qsPageSize == String.Empty) return 5;
            return Int32.Parse(qsPageSize);
        }

        public static int ProcessQsPageNumber(string qsPageNumber)
        {
            if (qsPageNumber == null) return 1;
            if (qsPageNumber == String.Empty) return 1;
            return Int32.Parse(qsPageNumber);
        }

        public static List<string> ProcessQsFamilia(string qsFamilias)
        {
            if (String.IsNullOrEmpty(qsFamilias))
                return new List<string>();
            List<string> qsFamiliaList = qsFamilias.Split(",").Select(s => s.Trim()).ToList();
            qsFamiliaList.RemoveAll(item => !int.TryParse(item, out _));
            return qsFamiliaList;
        }

        public static List<string> ProcessQsCasino(string qsCasinos)
        {
            if (String.IsNullOrEmpty(qsCasinos))
                return new List<string>();
            Regex regexCasino = new(@"^\d{4}([a-zA-Z]|){1}$");
            List<string> qsCasinoList = qsCasinos.Split(",").Select(s => s.Trim()).ToList();
            qsCasinoList.RemoveAll(item => !regexCasino.IsMatch(item));
            return qsCasinoList;
        }

        public static List<string> ProcessQsOcs(string qsOcs)
        {
            if (String.IsNullOrEmpty(qsOcs))
                return new List<string>();
            List<string> qsOcsList = qsOcs.Split(",").Select(s => s.Trim()).ToList();
            return qsOcsList;
        }

        public static List<string> ProcessQsProveedor(string qsProveedor)
        {
            if (String.IsNullOrEmpty(qsProveedor))
                return new List<string>();
            Regex regexProveedor = new(@"^([0-9]+-[0-9Kk])(/\d{3}|)$");
            List<string> qsProveedorList = qsProveedor.Split(",").Select(s => s.Trim()).ToList();
            qsProveedorList.RemoveAll(item => !regexProveedor.IsMatch(item));
            return qsProveedorList;
        }

        public static List<string> ProcessQsEjecutivo(string qsEjecutivo)
        {
            if (String.IsNullOrEmpty(qsEjecutivo))
                return new List<string>();
            Regex regexEjecutivo = new(@"^([0-9]+-[0-9Kk])(/\d{3}|)$");
            List<string> qsEjecutivoList = qsEjecutivo.Split(",").Select(s => s.Trim()).ToList();
            qsEjecutivoList.RemoveAll(item => !regexEjecutivo.IsMatch(item));
            return qsEjecutivoList;
        }

        public static DateTime ProcessQsFecha(string qsFecha)
        {
            Regex regexFecha = new(@"[0-9]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1]) (2[0-3]|[01][0-9]):[0-5][0-9]:[0-5][0-9]");
            return (regexFecha.IsMatch(qsFecha)) ? DateTime.Parse($"{qsFecha}") : DateTime.Now;
        }

        public static string ProcessQsOrdenamiento(string qsOrd)
        {
            if (String.IsNullOrEmpty(qsOrd))
                return "desc";
            List<string> sortingOptions = new() { "desc", "asc" };
            return (sortingOptions.Any(x => x == qsOrd)) ? qsOrd : "desc";
        }

        public static bool ProcessConDetalles(string qsConDetalles)
        {
            if (String.IsNullOrEmpty(qsConDetalles))
                return false;
            return Convert.ToBoolean(qsConDetalles);
        }

        public static List<StOrdenCompra> AddDetalleToOrdenCompra(List<QrOrdenCompraLinea> OrdenCompraLineas)
        {
            List<StOrdenCompra> OrdenCompraWithDetalle = new();
            List<StDetalleOrdenCompra> OrdenCompraDetalle = new();

            foreach (var item in OrdenCompraLineas)
            {
                var lastItem = OrdenCompraWithDetalle.LastOrDefault();

                // Factura
                StFactura stFactura = new();
                stFactura.Codigo = item.FolioFact;

                // Proveedor
                StProveedor stProveedor = new();
                stProveedor.Rut = item.IdProveedor;
                stProveedor.Nombre = item.NombreProveedor;

                // Centro de Costo
                StCentroCosto stCentroCosto = new();
                stCentroCosto.Codigo = item.IdCasino;
                stCentroCosto.Nombre = item.NombreCasino;

                // Orden Compra
                StOrdenCompra stOrdenCompra = new();
                stOrdenCompra.Numero = item.NumOc;
                stOrdenCompra.TipoCompra = item.TipoCompra;
                stOrdenCompra.CentroCosto = stCentroCosto;
                stOrdenCompra.Factura = stFactura;
                stOrdenCompra.Proveedor = stProveedor;
                stOrdenCompra.CentroCosto = stCentroCosto;
                stOrdenCompra.FechaDespacho = item.FechaDespacho;
                stOrdenCompra.CantidadLineasOriginales = item.CantLnOriginal;
                stOrdenCompra.CantidadLineasRecepcionadas = item.CantLnRecepcionadas;
                //stOrdenCompra.CantidadLineasRecepcionadas = (item.CantLnRecepcionadas == null) ? 0 : item.CantLnRecepcionadas;
                //stOrdenCompra.PorcentajeCumplimiento = Math.Round((decimal)(item.CantLnRecepcionadas / item.CantLnOriginal), 2);

                // Producto
                StProducto stProducto = new();
                stProducto.Codigo = item.CodigoProducto;
                stProducto.Nombre = item.NombreProducto;
                stProducto.Precio = item.Precio;
                stProducto.Unidad = item.Unidad;
                stProducto.Familia = item.Familia;

                // Detalle Orden Compra
                StDetalleOrdenCompra stDetalleOrdenCompra = new();
                stDetalleOrdenCompra.DetalleNumOc = item.DetalleNumOc;
                stDetalleOrdenCompra.Producto = stProducto;
                stDetalleOrdenCompra.Cantidad = item.Cantidad;

                foreach (var det in OrdenCompraDetalle.ToArray())
                    if (item.NumOc != det.DetalleNumOc)
                        OrdenCompraDetalle = new List<StDetalleOrdenCompra>();

                OrdenCompraDetalle.Add(stDetalleOrdenCompra);
                stOrdenCompra.Items = OrdenCompraDetalle;

                if (lastItem != null)
                    if (lastItem.Numero == item.NumOc)
                        continue;

                OrdenCompraWithDetalle.Add(stOrdenCompra);
            }

            return OrdenCompraWithDetalle;
        }
    }
}