namespace DashboardAbast.Shared.ChartDataModels
{
    public class CasinoItem
    {
        public string Nombre { get; set; }
        public DataItem[] Data { get; set; }

        public CasinoItem(string nombre, DataItem[] data)
        {
            this.Nombre = nombre;
            this.Data = data;
        }
    }
}
