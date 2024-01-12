using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
    public class CashCollectionDetailDto
    {
		public string SummaryCode { get; set; }

		public Nullable<DateTime> SummaryDate { get; set; }
		public string AllocationCode { get; set; }
		public string DACode { get; set; }
		public string InvoiceCode { get; set; }
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }
		public string InvoicePaymentMode { get; set; }
		public string CashPaymentMode { get; set; }
		public string InstrumentNumber { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<decimal> PartialDueAmount { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
	}
}
