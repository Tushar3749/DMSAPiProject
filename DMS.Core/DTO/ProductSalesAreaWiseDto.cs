using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO
{
	public class ProductSalesAreaWiseDto
	{
		public string ProductCode { get; set; }

		public Nullable<int> SoldQty { get; set; }
		public Nullable<int> ReturnQty { get; set; }
		public Nullable<int> BonusQty { get; set; }
		public string TerritoryCode { get; set; }
		public string TerritoryName { get; set; }

	}
}
