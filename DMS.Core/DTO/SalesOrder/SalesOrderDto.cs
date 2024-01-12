using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesOrder
{

	[Keyless]
    public class SalesOrderDto 
	{
		public Nullable<int> ID { get; set; }

		public string OrderCode { get; set; }
		public string ChemistCode { get; set; }
		public string ChemistName { get; set; }
		public string ChemistAddress { get; set; }
		public Nullable<DateTime> DeliveryDate { get; set; }
		public string PaymentMode { get; set; }

		public Nullable<Boolean> IsReceived { get; set; }
		public Nullable<int> NumberOfProducts { get; set; }
		public Nullable<decimal> AmountInTP { get; set; }

		public Nullable<DateTime> CreatedOn { get; set; }
		public Nullable<DateTime> ReceivedOn { get; set; }
		public Nullable<Boolean> IsActive { get; set; }
	}


}
