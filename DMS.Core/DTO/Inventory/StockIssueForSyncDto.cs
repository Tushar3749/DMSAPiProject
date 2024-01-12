using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
    public class StockIssueForSyncDto
    {
		public string IssueID { get; set; }

		public Nullable<DateTime> IssueDate { get; set; }
		public string IssueFrom { get; set; }
		public string FromWareHouseName { get; set; }
		public string IssueTo { get; set; }
		public string ToWareHouseName { get; set; }
		public string CreatedByID { get; set; }
		public Nullable<DateTime> CreatedOn { get; set; }
		public string IssueType { get; set; }
		public string Remarks { get; set; }
	}
}
