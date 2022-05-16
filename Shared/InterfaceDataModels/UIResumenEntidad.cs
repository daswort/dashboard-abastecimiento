namespace DashboardAbast.Shared.InterfaceDataModels
{
    public partial class UIResumenEntidad
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Total { get; set; }
        public int ATiempo { get; set; }
        public int Atrasada { get; set; }
        public int SinRegistro { get; set; }
        public int PorcATiempo { get; set; }
        public int PorcAtrasada { get; set; }
        public int PorcSinRegistro { get; set; }
    }
}
