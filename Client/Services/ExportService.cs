using Microsoft.AspNetCore.Components;
using Radzen;

namespace DashboardAbast.Client.Services
{
    public partial class ExportService
    {
        private readonly NavigationManager _navigationManager;

        public ExportService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public void Export(string table, string type, Query query = null)
        {
            _navigationManager.NavigateTo(query != null ? query.ToUrl($"/exportar/{table}/{type}") : $"/export/{table}/{type}", true);
        }
    }
}
