using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SalesOrder
{
	[Keyless]
    public class OrderTodayStatusDto 
	{
		public Nullable<int> NumberOfProducts { get; set; }

		public Nullable<decimal> AmountInTP { get; set; }
		public Nullable<int> NumberOfOrders { get; set; }
		public Nullable<int> NumberOfChemists { get; set; }
	}


}
