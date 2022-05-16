using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.PptoCe
{
    [Table("tbl_casino")]
    public partial class TblCasino
    {
        public string CentroCosto { get; set; } = null!;
        public int? IdEstado { get; set; }
        public int? IdEncargado { get; set; }
        public string? EmailCasino { get; set; }
        public int? IdInterlocutor { get; set; }
        public string? NumeroCelular { get; set; }
        public string? ModeloCelular { get; set; }
        public string? NoteBook { get; set; }
        public string? Modelo { get; set; }
        public string? Serie { get; set; }
        public int? Modem { get; set; }
        public int? IdCompania { get; set; }
        public int? AtiendeFeriado { get; set; }
        public int? IdAperturaCierre { get; set; }
        public int? IdDiaAtencion { get; set; }
        public string? FonoFijo { get; set; }
        public string? Correo2 { get; set; }
        public string? Correo3 { get; set; }
    }
}
