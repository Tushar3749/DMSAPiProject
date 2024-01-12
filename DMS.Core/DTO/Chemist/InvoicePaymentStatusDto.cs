using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Chemist
{

    [Keyless]
	public class InvoicePaymentStatusDto 
	{
        public long ROWNUMBER { get; set; }
        public string RegionCode { get; set; }

		public string REGIONNAME { get; set; }
		public string AreaCode { get; set; }
		public string AREANAME { get; set; }
		public string TerritoryCode { get; set; }
		public string TERRITORYNAME { get; set; }
        public string PaymentMode { get; set; }

        public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string InvoiceCode { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public Nullable<int> CreditDays { get; set; }

		public Nullable<int> InvoiceAge { get; set; }

        public Nullable<decimal> TotalTP { get; set; }
        public Nullable<decimal> TotalVAT { get; set; }
        public Nullable<decimal> AmountDiscount { get; set; }

        public Nullable<decimal> ProductDiscount { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
		public Nullable<decimal> OutstandingAmount { get; set; }


        public string DACode { get; set; }
        public string DeliveryAssistantName { get; set; }        
		public string MPOCode { get; set; }
        public string MPOName { get; set; }
        public string AllocationCode { get; set; }

        public string SummaryCode { get; set; }
        public Nullable<DateTime> SummaryDate { get; set; }
        //public string MoneyReceiptCode { get; set; }
        public Nullable<DateTime> MoneyReceiptDate { get; set; }
        public Nullable<int> NumberOfMR { get; set; }
        public Nullable<decimal> CreditNoteAdjustedAmount { get; set; }

    }

}
