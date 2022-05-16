using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.DespachosAtrasadosService
{
    public class DespachosAtrasadosService : IDespachosAtrasadosService
    {
        private readonly HttpClient _http;

        public DespachosAtrasadosService(HttpClient http)
        {
            _http = http;
        }

        public UIDespachosAtrasados DespachosAtrasados { get; set; } = new();

        public async Task GetDespachosAtrasadosGrid(
            DateTime fechaIni,
            DateTime fechaFin,
            IEnumerable<object> centroCosto,
            IEnumerable<object> proveedor,
            IEnumerable<object> familia,
            IEnumerable<object> ejecutivo
        )
        {
            string sFechaIni = Util.SetFechaToApi(fechaIni);
            string sFechafin = Util.SetFechaToApi(fechaFin);
            string sCentroCosto = Util.SetListObjectsForUrlApi(centroCosto);
            string sProveedor = Util.SetListObjectsForUrlApi(proveedor);
            string sFamilia = Util.SetListObjectsForUrlApi(familia);
            string sEjecutivo = Util.SetListObjectsForUrlApi(ejecutivo);

            string url = $"api/dashboard/despachos?fecha-ini={sFechaIni}&fecha-fin={sFechafin}&centro-costo={sCentroCosto}&proveedor={sProveedor}&ejecutivo={sEjecutivo}&familia={sFamilia}&page-size=5&page-number=1&con-detalles=true";

            Console.WriteLine($"API URL DESPACHOS ATRASADOS: {url}");

            var result = await _http.GetFromJsonAsync<UIDespachosAtrasados>(url);
            if (result != null)
                DespachosAtrasados = result;
        }
    }
}