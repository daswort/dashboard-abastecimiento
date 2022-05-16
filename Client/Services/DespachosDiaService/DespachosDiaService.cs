using Radzen;
using System.Net.Http;
using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.DespachosDiaService
{
    public class DespachosDiaService : IDespachosDiaService
    {
        private readonly HttpClient _http;
        private readonly Uri _baseUri;

        public DespachosDiaService(HttpClient http)
        {
            _http = http;
            _baseUri = new Uri("http://localhost:29495/api/");
        }

        public UIDespachosDelDia DespachosDias { get; set; } = new();

        public async Task GetDespachosDiasGrid(
            DateTime fechaIni,
            DateTime fechaFin,
            IEnumerable<object> centroCosto,
            IEnumerable<object> proveedor,
            IEnumerable<object> familia,
            IEnumerable<object> ejecutivo,
            int pageIndex,
            string columnName,
            string columnValue
        )
        {
            string sFechaIni = Util.SetFechaToApi(fechaIni);
            string sFechafin = Util.SetFechaToApi(fechaFin);
            string sCentroCosto = Util.SetListObjectsForUrlApi(centroCosto);
            string sProveedor = Util.SetListObjectsForUrlApi(proveedor);
            string sFamilia = Util.SetListObjectsForUrlApi(familia);
            string sEjecutivo = Util.SetListObjectsForUrlApi(ejecutivo);

            string url = $"api/dashboard/despachos?fecha-ini={sFechaIni}&fecha-fin={sFechafin}&centro-costo={sCentroCosto}&proveedor={sProveedor}&ejecutivo={sEjecutivo}&familia={sFamilia}&page-size=5&page-number={pageIndex}&con-detalles=true";

            Console.WriteLine($"API URL DESPACHOS DIA: {url}");

            var result = await _http.GetFromJsonAsync<UIDespachosDelDia>(url);
            if (result != null)
                DespachosDias = result;
        }
    }
}