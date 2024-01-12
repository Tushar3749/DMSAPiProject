using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    public class InvoiceSummaryDto
    {
		public string InvoiceCode { get; set; }

		public string DiscountCode { get; set; }
		public string ReturnType { get; set; }
		public Nullable<int> DiscountDetailID { get; set; }

		public Nullable<decimal> NetTP { get; set; }
		public Nullable<decimal> NetVat { get; set; }
		public Nullable<decimal> NetAmountDiscount { get; set; }
		public Nullable<decimal> NetProductDiscount { get; set; }
		public Nullable<decimal> TotalDiscount { get; set; }

		public Nullable<decimal> NetAmount { get; set; }
	}
}
