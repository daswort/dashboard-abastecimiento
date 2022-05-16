using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [NotMapped]
    public class ProveedorPorCasino
    {
        public string IdCasino { get; set; }

        public string NombreCasino { get; set; }
        
        public string IdProveedor { get; set; }
        
        public string NombreProveedor { get; set; }

        public int CantOcs { get; set; }

    }
}
