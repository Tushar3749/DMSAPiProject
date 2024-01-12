using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class DepotIssueDetailDto
    {
		public string IssueCode { get; set; }
		public string BatchNo { get; set; }
		public string ProductCode { get; set; }
		public string ProductName { get; set; }
		public Nullable<int> Quantity { get; set; }
	}
}
