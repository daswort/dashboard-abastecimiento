using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.FamiliaService
{
    public class FamiliaService : IFamiliaService
    {
        private readonly HttpClient _http;

        public List<CosFamilium> Familias { get; set; } = new List<CosFamilium>();

        public FamiliaService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetFamilias()
        {
            var result = await _http.GetFromJsonAsync<List<CosFamilium>>($"api/familia");
            if (result != null)
                Familias = result;
        }
    }
}