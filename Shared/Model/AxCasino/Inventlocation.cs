using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{

    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("INVENTLOCATION")]
    public partial class Inventlocation
    {
        [Column("INVENTLOCATIONID")]
        public string Inventlocationid { get; set; } = null!;
        [Column("NAME")]
        public string Name { get; set; } = null!;
        [Column("MANUAL")]
        public int Manual { get; set; }
        [Column("WMSLOCATIONIDDEFAULTRECEIPT")]
        public string Wmslocationiddefaultreceipt { get; set; } = null!;
        [Column("WMSLOCATIONIDDEFAULTISSUE")]
        public string Wmslocationiddefaultissue { get; set; } = null!;
        [Column("INVENTLOCATIONIDREQMAIN")]
        public string Inventlocationidreqmain { get; set; } = null!;
        [Column("REQREFILL")]
        public int Reqrefill { get; set; }
        [Column("INVENTLOCATIONTYPE")]
        public int Inventlocationtype { get; set; }
        [Column("INVENTLOCATIONIDQUARANTINE")]
        public string Inventlocationidquarantine { get; set; } = null!;
        [Column("INVENTLOCATIONLEVEL")]
        public int Inventlocationlevel { get; set; }
        [Column("REQCALENDARID")]
        public string Reqcalendarid { get; set; } = null!;
        [Column("WMSAISLENAMEACTIVE")]
        public int Wmsaislenameactive { get; set; }
        [Column("WMSRACKNAMEACTIVE")]
        public int Wmsracknameactive { get; set; }
        [Column("WMSRACKFORMAT")]
        public string Wmsrackformat { get; set; } = null!;
        [Column("WMSLEVELNAMEACTIVE")]
        public int Wmslevelnameactive { get; set; }
        [Column("WMSLEVELFORMAT")]
        public string Wmslevelformat { get; set; } = null!;
        [Column("WMSPOSITIONNAMEACTIVE")]
        public int Wmspositionnameactive { get; set; }
        [Column("WMSPOSITIONFORMAT")]
        public string Wmspositionformat { get; set; } = null!;
        [Column("INVENTLOCATIONIDTRANSIT")]
        public string Inventlocationidtransit { get; set; } = null!;
        [Column("VENDACCOUNT")]
        public string Vendaccount { get; set; } = null!;
        [Column("INVENTSITEID")]
        public string Inventsiteid { get; set; } = null!;
        [Column("PTB_WITHOUTCOUNTING")]
        public int PtbWithoutcounting { get; set; }
        [Column("DIMENSION")]
        public string Dimension { get; set; } = null!;
        [Column("DIMENSION2_")]
        public string Dimension2 { get; set; } = null!;
        [Column("DIMENSION3_")]
        public string Dimension3 { get; set; } = null!;
        [Column("DIMENSION4_")]
        public string Dimension4 { get; set; } = null!;
        [Column("CE_ROTULOPLATO")]
        public int CeRotuloplato { get; set; }
        [Column("CE_PRIORIDAD")]
        public string CePrioridad { get; set; } = null!;
        [Column("CE_STATUSPORTAL")]
        public string CeStatusportal { get; set; } = null!;
        [Column("CE_PASSPORTAL")]
        public string CePassportal { get; set; } = null!;
        [Column("CE_USERPORTAL")]
        public string CeUserportal { get; set; } = null!;
        [Column("CE_DESPACHOSABADO")]
        public int CeDespachosabado { get; set; }
        [Column("PTB_NEW")]
        public int PtbNew { get; set; }
        [Column("DATAAREAID")]
        public string Dataareaid { get; set; } = null!;
        [Column("RECVERSION")]
        public int Recversion { get; set; }
        [Column("RECID")]
        public long Recid { get; set; }
        [Column("CE_INICIOCASINO")]
        public DateTime CeIniciocasino { get; set; }
        [Column("CE_TIENEMAQUINAVALES")]
        public int CeTienemaquinavales { get; set; }
        [Column("CE_RESULTADOGESTION")]
        public int CeResultadogestion { get; set; }
        [Column("CE_PREMIACIONSELLOS")]
        public int CePremiacionsellos { get; set; }
        [Column("CE_CIERRECASINO")]
        public DateTime CeCierrecasino { get; set; }
        [Column("CE_CASINOPERDIDO")]
        public int CeCasinoperdido { get; set; }
        [Column("CE_RESTACOSTO")]
        public int CeRestacosto { get; set; }
        [Column("CE_TIENEVENTACONTADO")]
        public int CeTieneventacontado { get; set; }
        [Column("CE_DESCRIPCIONDESPACHO")]
        public string CeDescripciondespacho { get; set; } = null!;
    }
}
