namespace DashboardAbast.Shared.QueryModels
{
    public class RecepcionFolioFullSet
    { 
        public long? FolioFact { get; set; }
        public string? NumOc { get; set; }
        public string? CodigoProducto { get; set; }
        public string? Unidad { get; set; }
        public double? Cantidad { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public int? EstadoRecepcion { get; set; }
        public string? IdCasino { get; set; }
        public int? CantLnRecepcionadas { get; set; }
    }
}
