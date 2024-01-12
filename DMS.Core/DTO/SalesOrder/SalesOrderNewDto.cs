using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.SalesOrder
{
    public class SalesOrderNewDto
    {
		public Nullable<int> ID { get; set; }
		public string OrderCode { get; set; }
		public string TerritoryCode { get; set; }
		public string ChemistCode { get; set; }
		public string DepotID { get; set; }
		public Nullable<DateTime> DeliveryDate { get; set; }

		public string PaymentMode { get; set; }
		public string Remarks { get; set; }

		public Nullable<int> CreatedByID { get; set; }

        public string Detail { get; set; }
    }

	

}
