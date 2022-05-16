using Radzen;

namespace DashboardAbast.Client.Services.DespachosDiaService
{
    public interface IDespachosDiaService
    {
        UIDespachosDelDia DespachosDias { get; set; }

        Task GetDespachosDiasGrid(
            DateTime fechaIni,
            DateTime fechaFin,
            IEnumerable<object> centroCosto,
            IEnumerable<object> proveedor,
            IEnumerable<object> familia,
            IEnumerable<object> ejecutivo,
            int pageIndexDelDia,
            string filterColumn,
            string filterValue
        );
    }
}