namespace DashboardAbast.Client.Services.DespachosAtrasadosService
{
    public interface IDespachosAtrasadosService
    {
        UIDespachosAtrasados DespachosAtrasados { get; set; }

        Task GetDespachosAtrasadosGrid(
            DateTime fechaIni,
            DateTime fechaFin,
            IEnumerable<object> centroCosto,
            IEnumerable<object> proveedor,
            IEnumerable<object> familia,
            IEnumerable<object> ejecutivo
        );
    }
}