using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.Entidades.Modelos
{
    public partial class Jefatura
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Gerencia { get; set; }
        public List<string> CentrosCosto { get; set; } = new List<string>();
    }
}
