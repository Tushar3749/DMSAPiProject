using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
	[Keyless]
    public class InvoiceDetailSummaryDto
    {
		public string InvoiceCode { get; set; }

		public string AllocationCode { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string PackSize { get; set; }
		public string SalesCode { get; set; }

		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }
		public string InvDiscountCode { get; set; }
		public Nullable<int> InvDiscountDetailID { get; set; }
		public Nullable<int> InvInvoiceQty { get; set; }

		public Nullable<int> InvBonusQty { get; set; }
		public Nullable<decimal> InvTotalTP { get; set; }
		public Nullable<decimal> InvTotalVat { get; set; }
		public Nullable<decimal> InvProductDiscount { get; set; }
		public Nullable<decimal> InvTotalProductDiscount { get; set; }

		public Nullable<decimal> InvTotalAmountDiscount { get; set; }
		public Nullable<decimal> InvAmount { get; set; }
		public string DiscountCode { get; set; }
		public Nullable<int> DiscountDetailID { get; set; }
		public Nullable<int> SoldQty { get; set; }

		public Nullable<int> BonusQty { get; set; }
		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> ProductDiscount { get; set; }
		public Nullable<decimal> TotalProductDiscount { get; set; }

		public Nullable<decimal> TotalAmountDiscount { get; set; }
		public Nullable<decimal> Amount { get; set; }
		public Nullable<int> ReturnQty { get; set; }
	} 
}
