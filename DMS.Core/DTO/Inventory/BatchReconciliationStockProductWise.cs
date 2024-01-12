using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
	[Keyless]
    public class BatchReconciliationStockProductWise
    {
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public string UOM { get; set; }

		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public Nullable<int> ReceiveApprovalPendingQuantity { get; set; }
		public Nullable<int> ReceivePendingQuantity { get; set; }
		public Nullable<int> ReceiveQuantity { get; set; }
		public Nullable<int> IssueApprovalPendingQuantity { get; set; }
		public Nullable<int> IssuePendingQuantity { get; set; }

		public Nullable<int> IssueQuantity { get; set; }
		public Nullable<int> InvoicePendingAllocationQuantity { get; set; }
		public Nullable<int> InvoiceAllocationPendingDispatchQuantity { get; set; }
		public Nullable<int> InvoiceDispatchQuantity { get; set; }

		public Nullable<int> SummaryFinalizePendingQuantity { get; set; }
		public Nullable<int> SummaryTransitQuantity { get; set; }
		public Nullable<int> TransitQuantity { get; set; }

		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<int> ReturnQuantity { get; set; }

		public Nullable<int> PhysicalStock { get; set; }
		public Nullable<int> AvailableStock { get; set; }
	}
}
