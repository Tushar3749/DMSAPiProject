using System;

namespace DMS.Core.DTO.SalesOrder
{
    public class SalesOrderProductsDto
	{

		public Nullable<int> OrderID { get; set; }
		public Nullable<int> ProductID { get; set; }
		public Nullable<int> OrderQty { get; set; }
	}
}
