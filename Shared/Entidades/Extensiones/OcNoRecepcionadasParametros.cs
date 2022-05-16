using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.Entidades.Extensiones
{
    public class OcNoRecepcionadasParametros
    {
        public DateTime FechaIni { get; set; } = DateTime.Today;
        public DateTime FechaFin { get; set; } = DateTime.Today.AddDays(1).AddSeconds(-1);
        public List<string> OrdenesCompra { get; set; } = new List<string>();
        public List<string> CentrosCosto { get; set; }
        public List<string> Proveedores { get; set; }
        public List<string> Ejecutivos { get; set; }
        public List<string> Familias { get; set; }
        public string Ord { get; set; } = "desc";
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        private int _pageSize = 5;
    }
}
