using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class StockReceiveDetailPendingChallanDto
    {
		public string ChallanCode { get; set; }

		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public string SalesCode { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }

		public string BatchNo { get; set; }
		public Nullable<decimal> Quantity { get; set; }
		public Nullable<DateTime> ManufacturingDate { get; set; }
		public Nullable<DateTime> ExpiryDate { get; set; }
	}
}
