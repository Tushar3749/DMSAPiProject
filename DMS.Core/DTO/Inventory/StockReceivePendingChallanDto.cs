using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class StockReceivePendingChallanDto
    {
		public string ChallanCode { get; set; }

		public Nullable<DateTime> ChallanDate { get; set; }
		public string IssueTo { get; set; }
		public string ToWarehouseName { get; set; }
		public string IssueFrom { get; set; }
		public string FromWarehouseName { get; set; }

		public string IssueType { get; set; }
		public string Remarks { get; set; }
		public string ChallanApprovedByCode { get; set; }
		public string ChallanApprovedByName { get; set; }
		public string ApprovalRemarks { get; set; }

		public string VehicleNo { get; set; }
		public string VatChallanNo { get; set; }
		public Nullable<Boolean> IsFromCentralWareHouse { get; set; }
	}
}
