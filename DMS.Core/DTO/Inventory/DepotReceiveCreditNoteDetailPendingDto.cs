using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
	[Keyless]
    public class DepotReceiveCreditNoteDetailPendingDto
    {
		public string ProductCode { get; set; }

		public string ProductName { get; set; }
		public string PackSize { get; set; }
		public Nullable<decimal> TP { get; set; }
		public Nullable<decimal> Vat { get; set; }
		public string BatchNo { get; set; }

		public Nullable<int> Quantity { get; set; }
		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVat { get; set; }
		public Nullable<decimal> TPWithVat { get; set; }
	}
}
