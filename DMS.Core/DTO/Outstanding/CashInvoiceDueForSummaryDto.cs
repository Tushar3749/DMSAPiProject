using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Outstanding
{
	[Keyless]
	public class CashInvoiceDueForSummaryDto 
	{
		public string InvoiceCode { get; set; }

		public Nullable<decimal> InvoiceAmount { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string DACode { get; set; }
		public string EmployeeName { get; set; }
		public string Mobile { get; set; }

		public string PaymentMode { get; set; }
		public Nullable<int> Age { get; set; }
		public Nullable<decimal> PaidAmount { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
		public Nullable<decimal> NewPaidAmount { get; set; }

	}

}
