using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
	[Keyless]
    public class SummaryPendingCollectionDetailDto
    {
		public string SummaryCode { get; set; }

		public Nullable<DateTime> SummaryDate { get; set; }
		public string AllocationCode { get; set; }
		public string DACode { get; set; }
		public string InvoiceCode { get; set; }
		public string ChemistCode { get; set; }

		public string ChemistName { get; set; }
		public string PaymentMode { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<decimal> DueAmount { get; set; }
	}
}
