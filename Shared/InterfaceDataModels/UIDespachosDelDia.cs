using DashboardAbast.Shared.StandarizedDbModel;

namespace DashboardAbast.Shared.InterfaceDataModels
{
    public partial class UIDespachosDelDia
    {
        public int TotalLineas { get; set; }
        public int TotalLineasPorRecepcionar { get; set; }
        public int TotalLineasRecepcionadas { get; set; }
        public int TotalOc { get; set; }
        public int TotalOcPorRecepcionar { get; set; }
        public int TotalOcRecepcionadas { get; set; }
        public int TotalLineasSinRegistro { get; set; }
        public int TotalLineasRecepcionadasPerc { get; set; }
        public List<string> PagesPrev { get; set; } = new List<string>();
        public List<string> PagesCurr { get; set; } = new List<string>();
        public List<string> PagesNext { get; set; } = new List<string>();
        public List<StOrdenCompra> UIOrdenCompra { get; set; }
    }
}
