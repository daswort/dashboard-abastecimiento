using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.EjecutivoService
{
    public class EjecutivoService : IEjecutivoService
    {
        private readonly HttpClient _http;

        public List<TblEcRecurso> Ejecutivos { get; set; } = new List<TblEcRecurso>();

        public EjecutivoService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetEjecutivos()
        {
            var result = await _http.GetFromJsonAsync<List<TblEcRecurso>>($"api/ejecutivo");
            if (result != null)
                Ejecutivos = result;
        }
    }
}
