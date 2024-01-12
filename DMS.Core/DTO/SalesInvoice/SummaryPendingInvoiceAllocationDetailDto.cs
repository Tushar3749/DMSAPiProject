using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
	[Keyless]
    public class SummaryPendingInvoiceAllocationDetailDto
    {
		public string AllocationCode { get; set; }
		public string InvoiceCode { get; set; }

		public string ReturnType { get; set; }
		public Nullable<DateTime> InvoiceDate { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string TerritoryCode { get; set; }
		public string TerritoryName { get; set; }

		public Nullable<decimal> InvNetTP { get; set; }
		public Nullable<decimal> InvNetVat { get; set; }
		public Nullable<decimal> InvNetAmountDiscount { get; set; }
		public Nullable<decimal> InvNetProductDiscount { get; set; }
		public Nullable<decimal> InvTotalDiscount { get; set; }
		public Nullable<decimal> InvNetAmount { get; set; }

		public Nullable<decimal> NetTP { get; set; }
		public Nullable<decimal> NetVat { get; set; }
		public Nullable<decimal> NetAmountDiscount { get; set; }
		public Nullable<decimal> NetProductDiscount { get; set; }
		public Nullable<decimal> TotalDiscount { get; set; }

		public Nullable<decimal> NetAmount { get; set; }
	}
}
