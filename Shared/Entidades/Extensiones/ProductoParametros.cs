using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardAbast.Shared.Entidades.Extensiones
{
    public class ProductoParametros
    {
        public string? Codigo { get; set; }
        public List<string> ListaCodigo { get; set; } = new List<string>();
    }
}
