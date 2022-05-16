using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.Model.AxCasino
{

    [Microsoft.EntityFrameworkCore.Keyless]
    [Table("VENDTABLE")]
    public partial class Vendtable
    {
        [Column("ACCOUNTNUM")]
        public string Accountnum { get; set; } = null!;
        [Column("NAME")]
        public string Name { get; set; } = null!;
        [Column("ADDRESS")]
        public string Address { get; set; } = null!;
        [Column("PHONE")]
        public string Phone { get; set; } = null!;
        [Column("TELEFAX")]
        public string Telefax { get; set; } = null!;
        [Column("INVOICEACCOUNT")]
        public string Invoiceaccount { get; set; } = null!;
        [Column("VENDGROUP")]
        public string Vendgroup { get; set; } = null!;
        [Column("PAYMTERMID")]
        public string Paymtermid { get; set; } = null!;
        [Column("CASHDISC")]
        public string Cashdisc { get; set; } = null!;
        [Column("CURRENCY")]
        public string Currency { get; set; } = null!;
        [Column("LINEDISC")]
        public string Linedisc { get; set; } = null!;
        [Column("BLOCKED")]
        public int Blocked { get; set; }
        [Column("ONETIMEVENDOR")]
        public int Onetimevendor { get; set; }
        [Column("DIMENSION")]
        public string Dimension { get; set; } = null!;
        [Column("DIMENSION2_")]
        public string Dimension2 { get; set; } = null!;
        [Column("DIMENSION3_")]
        public string Dimension3 { get; set; } = null!;
        [Column("DIMENSION4_")]
        public string Dimension4 { get; set; } = null!;
        [Column("TELEX")]
        public string Telex { get; set; } = null!;
        [Column("PRICEGROUP")]
        public string Pricegroup { get; set; } = null!;
        [Column("MULTILINEDISC")]
        public string Multilinedisc { get; set; } = null!;
        [Column("ENDDISC")]
        public string Enddisc { get; set; } = null!;
        [Column("PAYMID")]
        public string Paymid { get; set; } = null!;
        [Column("CUSTACCOUNT")]
        public string Custaccount { get; set; } = null!;
        [Column("VATNUM")]
        public string Vatnum { get; set; } = null!;
        [Column("COUNTRYREGIONID")]
        public string Countryregionid { get; set; } = null!;
        [Column("INVENTLOCATION")]
        public string Inventlocation { get; set; } = null!;
        [Column("YOURACCOUNTNUM")]
        public string Youraccountnum { get; set; } = null!;
        [Column("DLVTERM")]
        public string Dlvterm { get; set; } = null!;
        [Column("DLVMODE")]
        public string Dlvmode { get; set; } = null!;
        [Column("BANKACCOUNT")]
        public string Bankaccount { get; set; } = null!;
        [Column("PAYMMODE")]
        public string Paymmode { get; set; } = null!;
        [Column("PAYMSPEC")]
        public string Paymspec { get; set; } = null!;
        [Column("MARKUPGROUP")]
        public string Markupgroup { get; set; } = null!;
        [Column("CLEARINGPERIOD")]
        public string Clearingperiod { get; set; } = null!;
        [Column("ZIPCODE")]
        public string Zipcode { get; set; } = null!;
        [Column("STATE")]
        public string State { get; set; } = null!;
        [Column("COUNTY")]
        public string County { get; set; } = null!;
        [Column("URL")]
        public string Url { get; set; } = null!;
        [Column("EMAIL")]
        public string Email { get; set; } = null!;
        [Column("CELLULARPHONE")]
        public string Cellularphone { get; set; } = null!;
        [Column("PHONELOCAL")]
        public string Phonelocal { get; set; } = null!;
        [Column("TAXGROUP")]
        public string Taxgroup { get; set; } = null!;
        [Column("FREIGHTZONE")]
        public string Freightzone { get; set; } = null!;
        [Column("CREDITRATING")]
        public string Creditrating { get; set; } = null!;
        [Column("CREDITMAX", TypeName = "decimal(32,12)")]
        public decimal Creditmax { get; set; }
        [Column("PAYMSCHED")]
        public string Paymsched { get; set; } = null!;
        [Column("NAMEALIAS")]
        public string Namealias { get; set; } = null!;
        [Column("ITEMBUYERGROUPID")]
        public string Itembuyergroupid { get; set; } = null!;
        [Column("CONTACTPERSONID")]
        public string Contactpersonid { get; set; } = null!;
        [Column("PURCHPOOLID")]
        public string Purchpoolid { get; set; } = null!;
        [Column("PURCHAMOUNTPURCHASEORDER")]
        public int Purchamountpurchaseorder { get; set; }
        [Column("INCLTAX")]
        public int Incltax { get; set; }
        [Column("VENDITEMGROUPID")]
        public string Venditemgroupid { get; set; } = null!;
        [Column("NUMBERSEQUENCEGROUP")]
        public string Numbersequencegroup { get; set; } = null!;
        [Column("LANGUAGEID")]
        public string Languageid { get; set; } = null!;
        [Column("PAYMDAYID")]
        public string Paymdayid { get; set; } = null!;
        [Column("DESTINATIONCODEID")]
        public string Destinationcodeid { get; set; } = null!;
        [Column("LINEOFBUSINESSID")]
        public string Lineofbusinessid { get; set; } = null!;
        [Column("SUPPITEMGROUPID")]
        public string Suppitemgroupid { get; set; } = null!;
        [Column("BANKCENTRALBANKPURPOSETEXT")]
        public string Bankcentralbankpurposetext { get; set; } = null!;
        [Column("BANKCENTRALBANKPURPOSECODE")]
        public string Bankcentralbankpurposecode { get; set; } = null!;
        [Column("CITY")]
        public string City { get; set; } = null!;
        [Column("STREET")]
        public string Street { get; set; } = null!;
        [Column("OFFSETACCOUNT")]
        public string Offsetaccount { get; set; } = null!;
        [Column("OFFSETACCOUNTTYPE")]
        public int Offsetaccounttype { get; set; }
        [Column("PURCHCALENDARID")]
        public string Purchcalendarid { get; set; } = null!;
        [Column("PAGER")]
        public string Pager { get; set; } = null!;
        [Column("SMS")]
        public string Sms { get; set; } = null!;
        [Column("PARTYID")]
        public string Partyid { get; set; } = null!;
        [Column("TAXWITHHOLDCALCULATE")]
        public int Taxwithholdcalculate { get; set; }
        [Column("TAXWITHHOLDGROUP")]
        public string Taxwithholdgroup { get; set; } = null!;
        [Column("NAMECONTROL")]
        public string Namecontrol { get; set; } = null!;
        [Column("INVENTSITEID")]
        public string Inventsiteid { get; set; } = null!;
        [Column("SEGMENTID")]
        public string Segmentid { get; set; } = null!;
        [Column("SUBSEGMENTID")]
        public string Subsegmentid { get; set; } = null!;
        [Column("COMPANYCHAINID")]
        public string Companychainid { get; set; } = null!;
        [Column("MAINCONTACTID")]
        public string Maincontactid { get; set; } = null!;
        [Column("VENDPRICETOLERANCEGROUPID")]
        public string Vendpricetolerancegroupid { get; set; } = null!;
        [Column("MEMO")]
        public string? Memo { get; set; }
        [Column("SMALLBUSINESS")]
        public int Smallbusiness { get; set; }
        [Column("PARTYTYPE")]
        public int Partytype { get; set; }
        [Column("LOCALLYOWNED")]
        public int Locallyowned { get; set; }
        [Column("BIDONLY")]
        public int Bidonly { get; set; }
        [Column("IDNUMBERSKIPCHECK")]
        public int Idnumberskipcheck { get; set; }
        [Column("BUSINESSDESCRIPTION")]
        public string Businessdescription { get; set; } = null!;
        [Column("PTB_RAPELL")]
        public int PtbRapell { get; set; }
        [Column("PTB_RAPELLTYPE")]
        public int PtbRapelltype { get; set; }
        [Column("PTB_PERCENTAGEVALUE", TypeName = "decimal(32,12)")]
        public decimal PtbPercentagevalue { get; set; }
        [Column("PTB_ADVERTISINGCONTRIBUTION")]
        public int PtbAdvertisingcontribution { get; set; }
        [Column("PTB_CONTRIBUTIONGOAL")]
        public int PtbContributiongoal { get; set; }
        [Column("PTB_FIXEDAMOUNT", TypeName = "decimal(32,12)")]
        public decimal PtbFixedamount { get; set; }
        [Column("PTB_FIXEDAMOUNTAC", TypeName = "decimal(32,12)")]
        public decimal PtbFixedamountac { get; set; }
        [Column("PTB_NETMINIMUNPURCHASE", TypeName = "decimal(32,12)")]
        public decimal PtbNetminimunpurchase { get; set; }
        [Column("PTB_PERCENTAGEOFCONTRIBUTION", TypeName = "decimal(32,12)")]
        public decimal PtbPercentageofcontribution { get; set; }
        [Column("CE_APROX")]
        public int CeAprox { get; set; }
        [Column("CE_USERPORTAL")]
        public string CeUserportal { get; set; } = null!;
        [Column("CE_PASSPORTAL")]
        public string CePassportal { get; set; } = null!;
        [Column("CE_DESPACHOSABADO")]
        public int CeDespachosabado { get; set; }
        [Column("MODIFIEDDATETIME")]
        public DateTime Modifieddatetime { get; set; }
        [Column("DEL_MODIFIEDTIME")]
        public int DelModifiedtime { get; set; }
        [Column("MODIFIEDBY")]
        public string Modifiedby { get; set; } = null!;
        [Column("CREATEDDATETIME")]
        public DateTime Createddatetime { get; set; }
        [Column("DEL_CREATEDTIME")]
        public int DelCreatedtime { get; set; }
        [Column("CREATEDBY")]
        public string Createdby { get; set; } = null!;
        [Column("DATAAREAID")]
        public string Dataareaid { get; set; } = null!;
        [Column("RECVERSION")]
        public int Recversion { get; set; }
        [Column("RECID")]
        public long Recid { get; set; }
        [Column("CDX_CUENTACONTRAPARTIDA")]
        public string CdxCuentacontrapartida { get; set; } = null!;
        [Column("CE_MONTODESPACHOMINIMO", TypeName = "decimal(32,12)")]
        public decimal CeMontodespachominimo { get; set; }
        [Column("CE_VALIDAREXTERNALITEMIDENOC")]
        public int CeValidarexternalitemidenoc { get; set; }
        [Column("CE_RECEPCIONDOCTOS")]
        public int CeRecepciondoctos { get; set; }
        [Column("CE_HRDESPACHODESDE")]
        public int CeHrdespachodesde { get; set; }
        [Column("CE_HRDESPACHOHASTA")]
        public int CeHrdespachohasta { get; set; }
    }
}
