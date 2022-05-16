using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.JefaturaService
{
    public class JefaturaService : IJefaturaService
    {
        private readonly HttpClient _http;

        public List<Jefatura> Jefaturas { get; set; } = new List<Jefatura>();

        public JefaturaService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetJefaturas(string jefatura = "")
        {
            var result = await _http.GetFromJsonAsync<List<Jefatura>>($"api/jefatura?gerencia={jefatura}");
            if (result != null)
                Jefaturas = result;
        }
    }
}
