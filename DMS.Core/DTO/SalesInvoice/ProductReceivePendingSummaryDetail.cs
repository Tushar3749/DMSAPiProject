
using DMS.Core.Models.SummaryInvoice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
	[Keyless]
    public class ProductReceivePendingSummaryDetail
    {
		public string SummaryCode { get; set; }

		public string AllocationCode { get; set; }
		public string InvoiceCode { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string PackSize { get; set; }

		public string SPS { get; set; }
		public Nullable<int> InvoiceQuantity { get; set; }
		public Nullable<int> SoldQuantity { get; set; }
		public Nullable<int> InvoiceReturnQty { get; set; }
		public Nullable<int> ReturnQty { get; set; }
		public List<SummaryInvoiceProductBatchWise> ProductBatch { get; set; }
	}
}
