using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.InterfaceDataModels
{
    [NotMapped]
    [Microsoft.EntityFrameworkCore.Keyless]
    public partial class DetalleOrdenCompra
    {
        public string NumOc { get; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public string TipoOc { get; set; }
        public string Cantidad { get; set; }

    }
}
