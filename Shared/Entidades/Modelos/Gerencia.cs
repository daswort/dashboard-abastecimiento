namespace DashboardAbast.Shared.Entidades.Modelos
{
    public partial class Gerencia
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Division { get; set; }
        public List<string> Jefaturas { get; set; } = new List<string>();
        public List<string> CentrosCosto { get; set; } = new List<string>();
    }
}
