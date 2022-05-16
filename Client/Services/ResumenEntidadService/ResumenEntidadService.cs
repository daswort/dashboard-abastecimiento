using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.ResumenEntidadService
{
    public class ResumenEntidadService : IResumenEntidadService
    {
        private readonly HttpClient _http;

        public List<UIResumenEntidad> ResumenEntidades { get; set; } = new List<UIResumenEntidad>();

        public ResumenEntidadService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetResumenEntidad(
            string entidad, 
            DateTime fechaIni, 
            DateTime fechaFin,
            IEnumerable<object>? centroCosto = null,
            IEnumerable<object>? proveedor = null,
            IEnumerable<object>? familia = null,
            IEnumerable<object>? ejecutivo = null
        )
        {

            string sFechaIni = Util.SetFechaToApi(fechaIni);
            string sFechafin = Util.SetFechaToApi(fechaFin);
            string sCentroCosto = Util.SetListObjectsForUrlApi(centroCosto);
            string sProveedor = Util.SetListObjectsForUrlApi(proveedor);
            string sFamilia = Util.SetListObjectsForUrlApi(familia);
            string sEjecutivo = Util.SetListObjectsForUrlApi(ejecutivo);

            string url = $"api/{entidad}?fecha-ini={sFechaIni}&fecha-fin={sFechafin}&centro-costo={sCentroCosto}&proveedor={sProveedor}&ejecutivo={sEjecutivo}&familia={sFamilia}";

            Console.WriteLine($"API URL RESUMEN ENTIDADES: {url}");

            var result = await _http.GetFromJsonAsync<List<UIResumenEntidad>>(url);
            if (result != null)
                ResumenEntidades = result;
        }
    }
}
