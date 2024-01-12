using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SummaryReturn
{
	[Keyless]
    public class SalesInvoiceDateBetweenDto
    {
		public string InvoiceCode { get; set; }

		public Nullable<DateTime> InvoiceDate { get; set; }
		public int InvoiceAge { get; set; }
		public string PaymentMode { get; set; }
		public string TerritoryCode { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }

		public string TerritoryName { get; set; }
		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> TotalProductDiscount { get; set; }
		public Nullable<decimal> TotalAmountDiscount { get; set; }

		public Nullable<decimal> Amount { get; set; }
		public string AllocationCode { get; set; }
		public Nullable<DateTime> AllocationDate { get; set; }
		public string DACode { get; set; }
		public string DAName { get; set; }
		public string MPOCode { get; set; }
		public string MPOName { get; set; }

		public Nullable<Boolean> IsAllocationDone { get; set; }
		public string SummaryCode { get; set; }
		public Nullable<DateTime> SummaryDate { get; set; }
		public Nullable<Boolean> IsSummaryDone { get; set; }
	}
    [Keyless]
    public class SalesInvoiceNewDateBetwwen
    {
        public string TerritoryCode { get; set; }

        public string MPOCode { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<decimal> TotalTP { get; set; }
        public Nullable<decimal> TotalVat { get; set; }
        public Nullable<decimal> TotalAmountDiscount { get; set; }

        public Nullable<decimal> TotalProductDiscount { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
