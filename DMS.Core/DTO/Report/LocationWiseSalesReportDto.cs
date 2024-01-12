using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report
{

	[Keyless]
    public class LocationWiseSalesReportDto 
	{
		public string RegionID { get; set; }
		public string RegionName { get; set; }
		public string RegionalManagerID { get; set; }
		public string RegionalManagerName { get; set; }

		public string AreaID { get; set; }
		public string AreaName { get; set; }
		public string AreaManagerID { get; set; }
		public string AreaManagerName { get; set; }
		public string TerritoryID { get; set; }
		public string TerritoryName { get; set; }

		public string MPOID { get; set; }
		public string MPOName { get; set; }
		public Nullable<int> TransitInvoiceNumber { get; set; }
		public Nullable<decimal> TransitTP { get; set; }
		public Nullable<decimal> TransitVAT { get; set; }

		public Nullable<decimal> TransitTradeDiscount { get; set; }
		public Nullable<decimal> TransitProductDiscount { get; set; }
		public Nullable<int> SoldInvoiceNumber { get; set; }
		public Nullable<decimal> SoldTP { get; set; }
		public Nullable<decimal> SoldVAT { get; set; }

		public Nullable<decimal> SoldTradeDiscount { get; set; }
		public Nullable<decimal> SoldProductDiscount { get; set; }
		public Nullable<decimal> ReturnValue { get; set; }

	}


	public class LocationWiseSalesTerritoryDetails
	{

		public string TerritoryID { get; set; }
		public string TerritoryName { get; set; }

		public string MPOID { get; set; }
		public string MPOName { get; set; }
		public Nullable<int> TransitInvoiceNumber { get; set; }
		public Nullable<decimal> TransitTP { get; set; }
		public Nullable<decimal> TransitVAT { get; set; }

		public Nullable<decimal> TransitTradeDiscount { get; set; }
		public Nullable<decimal> TransitProductDiscount { get; set; }
		public Nullable<decimal> TransitAmount { get; set; }



		public Nullable<int> SoldInvoiceNumber { get; set; }
		public Nullable<decimal> SoldTP { get; set; }
		public Nullable<decimal> SoldVAT { get; set; }

		public Nullable<decimal> SoldTradeDiscount { get; set; }
		public Nullable<decimal> SoldProductDiscount { get; set; }
		public Nullable<decimal> SoldAmount { get; set; }


		public Nullable<decimal> TotalTP { get; set; }
		public Nullable<decimal> TotalVAT { get; set; }

		public Nullable<decimal> TotalTradeDiscount { get; set; }
		public Nullable<decimal> TotalProductDiscount { get; set; }
		public Nullable<decimal> TotalAmount { get; set; }
		public Nullable<decimal> ReturnValue { get; set; }
	}
	
}
