using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.GerenciaService
{
    public class GerenciaService : IGerenciaService
    {
        private readonly HttpClient _http;

        public List<Gerencia> Gerencias { get; set; } = new List<Gerencia>();

        public GerenciaService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetGerencias(string division = "")
        {
            var result = await _http.GetFromJsonAsync<List<Gerencia>>($"api/gerencia?division={division}");
            if (result != null)
                Gerencias = result;
        }
    }
}
