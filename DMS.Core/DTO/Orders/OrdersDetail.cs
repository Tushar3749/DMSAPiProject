
/*
 *=============================================
 *Author: Shamsul Hasan Siam
 *Email: siam.it@labaidpharma.com
 *Created on: 7 june 2020
 *Updated on: 
 *Last updated on:
 *Description: <>
 *=============================================
*/


using System;

namespace DMS.Core.DTO.Orders
{
    public class OrdersDetailDto 
	{
		public Nullable<int> ID { get; set; }

		public string OrderCode { get; set; }
		public string ProductCode { get; set; }
		public Nullable<int> Quantity { get; set; }
		public string MachineID { get; set; }
		public string CreatedByID { get; set; }
	}

}
