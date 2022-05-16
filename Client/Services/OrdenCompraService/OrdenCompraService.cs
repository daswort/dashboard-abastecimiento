using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;

namespace DashboardAbast.Client.Services.OrdenCompraService
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public OrdenCompraService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<TblOrdenCompra> OrdenCompras { get; set; } = new List<TblOrdenCompra>();
        public List<ProveedorItem> ProveedorPorCasinos { get; set; }  = new List<ProveedorItem>();
        public List<TablaPorCasino> TablaPorCasino { get; set; }  = new List<TablaPorCasino>();

        public async Task GetOrdenCompras(string fechaIni, string fechaFin)
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);


            var result = await _http.GetFromJsonAsync<List<TblOrdenCompra>>($"api/dashboard/ordencompra?fecha-ini={fechaIni}&fecha-fin={fechaFin}");
            if (result != null)
                OrdenCompras = result;
        }

        public async Task GetOrdenesCompraPorCasinoGrafico(string fechaIni, string fechaFin, string casinos)
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);

            var result = await _http.GetFromJsonAsync<List<ProveedorItem>>($"api/dashboard/ordencompra/por-casino/grafico?fecha-ini={fechaIni}&fecha-fin={fechaFin}&casino={casinos}");

            if (result != null)
                ProveedorPorCasinos = result;
        }

        public async Task GetOrdenesCompraPorCasinoTabla(string fechaIni, string fechaFin, string casinos)
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);

            var result = await _http.GetFromJsonAsync<List<TablaPorCasino>>($"api/dashboard/ordencompra/por-casino/tabla?fecha-ini={fechaIni}&fecha-fin={fechaFin}&casino={casinos}");

            if (result != null)
                TablaPorCasino = result;
        }

    }
}
