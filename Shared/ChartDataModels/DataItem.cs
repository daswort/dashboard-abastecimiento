namespace DashboardAbast.Shared.ChartDataModels
{
    public class DataItem
    {
        public string Entidad { get; set; }
        public int CantidadOcs { get; set; }

        public DataItem(string entidad, int cantidadOcs)
        {
            this.Entidad = entidad;
            this.CantidadOcs = cantidadOcs;
        }
    }
}
