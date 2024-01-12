using System;

namespace DMS.Core.Dto.SalesOrder
{
    public class AppSalesOrderDto 
	{
		public string OrderCode { get; set; }
		public string TerritoryCode { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string DepotCode { get; set; }
		public Nullable<DateTime> DeliveryDate { get; set; }
		public string DeliveryTime { get; set; }

		public string PaymentMode { get; set; }
		public Nullable<int> NumberOfProducts { get; set; }
		public Nullable<decimal> AmountInTP { get; set; }
		public string ChemistAddress { get; set; }

		public Nullable<DateTime> CreatedOn { get; set; }
		public Nullable<int> CreatedByID { get; set; }
		public string OrderByID { get; set; }
		
	}


	
}
