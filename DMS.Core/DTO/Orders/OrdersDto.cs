
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

	public class OrdersDto 
	{
		public Nullable<int> ID { get; set; }

		public string OrderCode { get; set; }
		public Nullable<DateTime> OrderDate { get; set; }
		public string ChemistCode { get; set; }
		public string TerritoryCode { get; set; }
		public string DepotCode { get; set; }

		public Nullable<DateTime> DeliveryDate { get; set; }
		public string DeliveryTime { get; set; }
		public string PaymentMode { get; set; }
		public string OrderMedia { get; set; }
		public string Remarks { get; set; }

		public string MachineID { get; set; }
		public Nullable<int> CreatedByID { get; set; }
		public string MPOCode { get; set; }
		public string LabaidEmployeeCode { get; set; }
		public string Detail { get; set; }
		
	}


}
