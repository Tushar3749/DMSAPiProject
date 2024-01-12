using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesOrder
{
	[Keyless]
    public class ProductsDto 
	{
		public string ProductName { get; set; }

		public string ProductCode { get; set; }
		public string PackSize { get; set; }
		public Nullable<decimal> TP { get; set; }

		public Nullable<decimal> VAT { get; set; }
		public Nullable<decimal> MRP { get; set; }
		public string SPS { get; set; }
		public string SalesCode { get; set; }
		public Nullable<int> IsBonusProduct { get; set; }
	}

}
