using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
    public class StockInfoDateBetweenDto
    {
		public string ProductCode { get; set; }

		public string BatchNo { get; set; }
		public Nullable<int> OpeningQty { get; set; }
		public Nullable<int> ReceiveQuantity { get; set; }
		public Nullable<int> IssueQuantity { get; set; }
		public Nullable<int> InvoiceQuantity { get; set; }

		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<int> ReturnQuantity { get; set; }
		public Nullable<int> SummaryTransit { get; set; }
		public Nullable<int> TransitQunatity { get; set; }
		public Nullable<int> StockQty { get; set; }

		public string ProductName { get; set; }
		public string SalesCode { get; set; }
		public string PackSize { get; set; }
		public string UOM { get; set; }
		public Nullable<decimal> TP { get; set; }

		public Nullable<decimal> Vat { get; set; }
		public Nullable<int> TotalStockQty { get; set; }
	}
}
