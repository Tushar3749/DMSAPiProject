using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.Orders.OrderReport
{
	[Keyless]
    public class SalesOrderReportDto
    {
		public Nullable<int> ID { get; set; }

		public string OrderCode { get; set; }
		public string MPOCode { get; set; }
		public string DepotCode { get; set; }
		public string TerritoryCode { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }

		public Nullable<DateTime> DeliveryDate { get; set; }
		public string DeliveryTime { get; set; }
		public string PaymentMode { get; set; }
		public Nullable<int> NumberOfProducts { get; set; }

		public Nullable<decimal> AmountInTP { get; set; }
		public string ChemistAddress { get; set; }
		public string CreatedByID { get; set; }
		public string OrderByID { get; set; }

		public List<SalesOrderReportDetailDto> Detail { get; set; }
	}
}
