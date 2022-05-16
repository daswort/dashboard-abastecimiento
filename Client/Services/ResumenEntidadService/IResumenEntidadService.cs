namespace DashboardAbast.Client.Services.ResumenEntidadService
{
    public interface IResumenEntidadService
    {
        List<UIResumenEntidad> ResumenEntidades { get; set; }

        Task GetResumenEntidad(
            string entidad, 
            DateTime fechaIni, 
            DateTime fechaFin,
            IEnumerable<object>? centroCosto = null,
            IEnumerable<object>? proveedor = null,
            IEnumerable<object>? familia = null,
            IEnumerable<object>? ejecutivo = null
        );
    }
}
