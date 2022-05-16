using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{
    [Table("PURCHTABLE")]
    public partial class Purchtable
    {
        [Key]
        [Column("PURCHID")]
        public string Purchid { get; set; } = null!;
        [Column("PURCHNAME")]
        public string Purchname { get; set; } = null!;
        [Column("ORDERACCOUNT")]
        public string Orderaccount { get; set; } = null!;
        [Column("INVOICEACCOUNT")]
        public string Invoiceaccount { get; set; } = null!;
        [Column("FREIGHTZONE")]
        public string Freightzone { get; set; } = null!;
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        [Column("DELIVERYDATE")]
        public DateTime Deliverydate { get; set; }
        [Column("DELIVERYTYPE")]
        public int Deliverytype { get; set; }
        [Column("ADDRESSREFRECID")]
        public long Addressrefrecid { get; set; }
        [Column("ADDRESSREFTABLEID")]
        public int Addressreftableid { get; set; }
        [Column("INTERCOMPANYORIGINALSALESID")]
        public string Intercompanyoriginalsalesid { get; set; } = null!;
        [Column("INTERCOMPANYORIGINALCUSTACCO12")]
        public string Intercompanyoriginalcustacco12 { get; set; } = null!;
        [Column("CURRENCYCODE")]
        public string Currencycode { get; set; } = null!;
        [Column("PAYMENT")]
        public string Payment { get; set; } = null!;
        [Column("CASHDISC")]
        public string Cashdisc { get; set; } = null!;
        [Column("PURCHPLACER")]
        public string Purchplacer { get; set; } = null!;
        [Column("VENDGROUP")]
        public string Vendgroup { get; set; } = null!;
        [Column("LINEDISC")]
        public string Linedisc { get; set; } = null!;
        [Column("DISCPERCENT", TypeName = "decimal(32,12)")]
        public decimal Discpercent { get; set; }
        [Column("DIMENSION")]
        public string Dimension { get; set; } = null!;
        [Column("DIMENSION2_")]
        public string Dimension2 { get; set; } = null!;
        [Column("DIMENSION3_")]
        public string Dimension3 { get; set; } = null!;
        [Column("DIMENSION4_")]
        public string Dimension4 { get; set; } = null!;
        [Column("PRICEGROUPID")]
        public string Pricegroupid { get; set; } = null!;
        [Column("MULTILINEDISC")]
        public string Multilinedisc { get; set; } = null!;
        [Column("ENDDISC")]
        public string Enddisc { get; set; } = null!;
        [Column("INTERCOMPANYCUSTPURCHORDERFO26")]
        public string Intercompanycustpurchorderfo26 { get; set; } = null!;
        [Column("DELIVERYADDRESS")]
        public string Deliveryaddress { get; set; } = null!;
        [Column("TAXGROUP")]
        public string Taxgroup { get; set; } = null!;
        [Column("DLVTERM")]
        public string Dlvterm { get; set; } = null!;
        [Column("DLVMODE")]
        public string Dlvmode { get; set; } = null!;
        [Column("PURCHSTATUS")]
        public int Purchstatus { get; set; }
        [Column("MARKUPGROUP")]
        public string Markupgroup { get; set; } = null!;
        [Column("PURCHASETYPE")]
        public int Purchasetype { get; set; }
        [Column("URL")]
        public string Url { get; set; } = null!;
        [Column("POSTINGPROFILE")]
        public string Postingprofile { get; set; } = null!;
        [Column("TRANSACTIONCODE")]
        public string Transactioncode { get; set; } = null!;
        [Column("DELIVERYZIPCODE")]
        public string Deliveryzipcode { get; set; } = null!;
        [Column("DLVCOUNTY")]
        public string Dlvcounty { get; set; } = null!;
        [Column("DLVCOUNTRYREGIONID")]
        public string Dlvcountryregionid { get; set; } = null!;
        [Column("DLVSTATE")]
        public string Dlvstate { get; set; } = null!;
        [Column("SETTLEVOUCHER")]
        public int Settlevoucher { get; set; }
        [Column("CASHDISCPERCENT", TypeName = "decimal(32,12)")]
        public decimal Cashdiscpercent { get; set; }
        [Column("DELIVERYNAME")]
        public string Deliveryname { get; set; } = null!;
        [Column("COVSTATUS")]
        public int Covstatus { get; set; }
        [Column("PAYMENTSCHED")]
        public string Paymentsched { get; set; } = null!;
        [Column("INVENTSITEID")]
        public string Inventsiteid { get; set; } = null!;
        [Column("ONETIMEVENDOR")]
        public int Onetimevendor { get; set; }
        [Column("RETURNITEMNUM")]
        public string Returnitemnum { get; set; } = null!;
        [Column("FREIGHTSLIPTYPE")]
        public int Freightsliptype { get; set; }
        [Column("DOCUMENTSTATUS")]
        public int Documentstatus { get; set; }
        [Column("CONTACTPERSONID")]
        public string Contactpersonid { get; set; } = null!;
        [Column("INVENTLOCATIONID")]
        public string Inventlocationid { get; set; } = null!;
        [Column("ITEMBUYERGROUPID")]
        public string Itembuyergroupid { get; set; } = null!;
        [Column("PROJID")]
        public string Projid { get; set; } = null!;
        [Column("PURCHPOOLID")]
        public string Purchpoolid { get; set; } = null!;
        [Column("VATNUM")]
        public string Vatnum { get; set; } = null!;
        [Column("PORT")]
        public string Port { get; set; } = null!;
        [Column("INCLTAX")]
        public int Incltax { get; set; }
        [Column("NUMBERSEQUENCEGROUP")]
        public string Numbersequencegroup { get; set; } = null!;
        [Column("LANGUAGEID")]
        public string Languageid { get; set; } = null!;
        [Column("AUTOSUMMARYMODULETYPE")]
        public int Autosummarymoduletype { get; set; }
        [Column("TRANSPORT")]
        public string Transport { get; set; } = null!;
        [Column("PAYMMODE")]
        public string Paymmode { get; set; } = null!;
        [Column("PAYMSPEC")]
        public string Paymspec { get; set; } = null!;
        [Column("FIXEDDUEDATE")]
        public DateTime Fixedduedate { get; set; }
        [Column("DELIVERYCITY")]
        public string Deliverycity { get; set; } = null!;
        [Column("DELIVERYSTREET")]
        public string Deliverystreet { get; set; } = null!;
        [Column("STATPROCID")]
        public string Statprocid { get; set; } = null!;
        [Column("VENDORREF")]
        public string Vendorref { get; set; } = null!;
        [Column("RETURNREASONCODEID")]
        public string Returnreasoncodeid { get; set; } = null!;
        [Column("RETURNREPLACEMENTCREATED")]
        public int Returnreplacementcreated { get; set; }
        [Column("REQATTENTION")]
        public string Reqattention { get; set; } = null!;
        [Column("REQUISITIONER")]
        public string Requisitioner { get; set; } = null!;
        [Column("PTB_RAPELL")]
        public int PtbRapell { get; set; }
        [Column("PTB_CONTRIBUTIONGOAL")]
        public int PtbContributiongoal { get; set; }
        [Column("PTB_FOLIO")]
        public string PtbFolio { get; set; } = null!;
        [Column("PTB_SENDEDTOPOP")]
        public int PtbSendedtopop { get; set; }
        [Column("PTB_REASON")]
        public string PtbReason { get; set; } = null!;
        [Column("CE_RECIBIDA")]
        public int CeRecibida { get; set; }
        [Column("PTB_REGISTERERROR")]
        public string PtbRegistererror { get; set; } = null!;
        [Column("CREATEDDATETIME")]
        public DateTime Createddatetime { get; set; }
        [Column("DATAAREAID")]
        public string Dataareaid { get; set; } = null!;
        [Column("RECVERSION")]
        public int Recversion { get; set; }
        [Column("RECID")]
        public long Recid { get; set; }
        [Column("CE_ACUMULADO")]
        public int CeAcumulado { get; set; }
        [Column("CE_VISIBLEPROVEEDOR")]
        public int CeVisibleproveedor { get; set; }
        [Column("CE_STATUS")]
        public int CeStatus { get; set; }
        [Column("CE_MARK_OC")]
        public int CeMarkOc { get; set; }
        [Column("CREATEDBY")]
        public string Createdby { get; set; } = null!;
        [Column("MODIFIEDDATETIME")]
        public DateTime Modifieddatetime { get; set; }
        [Column("MODIFIEDBY")]
        public string Modifiedby { get; set; } = null!;
        [Column("CE_XML_ICONSTRUYE")]
        public int CeXmlIconstruye { get; set; }
        [Column("VARIABLE")]
        public int Variable { get; set; }
        [Column("CE_IDFAMILIA")]
        public long CeIdfamilia { get; set; }
        [Column("CE_XML_B2B_PROVEEDOR")]
        public int CeXmlB2bProveedor { get; set; }
        [Column("COS_IDSUBFAMILIA")]
        public string? CosIdsubfamilia { get; set; } = null!;
        [Column("COS_IDFAMILIA")]
        public string? CosIdfamilia { get; set; } = null!;
        [Column("CE_OCDESCARGADAEXCELPROV")]
        public int CeOcdescargadaexcelprov { get; set; }
        [Column("CE_OCDESCARGADAXMLPROV")]
        public int CeOcdescargadaxmlprov { get; set; }
        [Column("CE_FECHADESPCONFIRMPROV")]
        public DateTime CeFechadespconfirmprov { get; set; }
    }
}
