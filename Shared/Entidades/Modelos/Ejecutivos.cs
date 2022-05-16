namespace DashboardAbast.Shared.Entidades.Modelos
{
    public partial class Ejecutivo
    {
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? CentroCosto { get; set; }
        public List<CentroCosto>? CentrosCosto { get; set; }
    }
}
