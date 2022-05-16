using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.CentroCostoService
{
    public class CentroCostoService : ICentroCostoService
    {
        private readonly HttpClient _http;
        public List<CentroCosto> CentrosCosto { get; set; } = new List<CentroCosto>();

        public CentroCostoService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
        }

        public async Task GetCentrosCosto()
        {
            var result = await _http.GetFromJsonAsync<List<CentroCosto>>($"api/centro-costo");
            if (result != null)
                CentrosCosto = result;
        }

        public async Task GetCentrosCostoPorJefatura(string jefatura = "")
        {
            var result = await _http.GetFromJsonAsync<List<CentroCosto>>($"api/centro-costo/jefatura?codigo={jefatura}");
            if (result != null)
                CentrosCosto = result;
        }

        public async Task<CentroCosto> GetSingleCentroCosto(string id)
        {
            var result = await _http.GetFromJsonAsync<CentroCosto>($"api/centro-costo/{id}");
            if (result != null)
                return result;
            throw new Exception($"No se encontró el casino con el ID {id}");
        }
    }
}
