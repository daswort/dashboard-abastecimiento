using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.Entidades.Extensiones
{
    public class ProveedorParametros
    {
        public string? Rut { get; set; }
        public List<string> ListaRut { get; set; } = new List<string>();
    }
}
