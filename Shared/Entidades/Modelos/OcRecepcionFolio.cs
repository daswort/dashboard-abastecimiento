using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.Entidades.Modelos
{
    public class OcRecepcionFolio
    {
        public string? NumOc { get; set; }
        public string? CodigoProducto { get; set; }
        public string? CentroCosto { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public int? EstadoRecepcion { get; set; }
    }
}
