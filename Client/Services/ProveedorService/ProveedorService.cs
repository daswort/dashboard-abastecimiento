using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace DashboardAbast.Client.Services.ProveedorService
{
    public class ProveedorService : IProveedorService
    {
        private readonly HttpClient _http;

        public List<TblProveedore> Proveedores { get; set; } = new List<TblProveedore>();

        public ProveedorService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
        }

        public async Task GetProveedores(DateTime fechaIni, DateTime fechaFin)
        {
            string sFechaIni = Util.SetFechaToApi(fechaIni);
            string sFechafin = Util.SetFechaToApi(fechaFin);

            string url = $"api/dashboard/proveedores?fecha-ini={sFechaIni}&fecha-fin={sFechafin}";

            Console.WriteLine($"API URL PROVEEDORES DIA: {url}");

            var result = await _http.GetFromJsonAsync<List<TblProveedore>>(url);
            if (result != null)
                Proveedores = result;
        }
    }
}