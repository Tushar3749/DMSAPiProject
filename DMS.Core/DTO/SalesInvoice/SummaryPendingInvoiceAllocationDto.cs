using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
	[Keyless]
    public class SummaryPendingInvoiceAllocationDto
    {
		public bool IsSummaryPendingInvoice { get; set; }
		public string AllocationCode { get; set; }

		public string DACode { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<DateTime> AllocationDate { get; set; }
		public Nullable<int> NoOfDaysPassed { get; set; }
		public Nullable<int> NumberOfInvoice { get; set; }

		public Nullable<decimal> Amount { get; set; }
		public Nullable<decimal> SummaryAmount { get; set; }
		public Nullable<DateTime> ReturnDate { get; set; }
	}
}
