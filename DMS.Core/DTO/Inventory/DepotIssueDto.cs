using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
    public class DepotIssueDto
    {
		public string IssueCode { get; set; }
		public Nullable<DateTime> IssueDate { get; set; }
		public string IssueType { get; set; }
		public string RequisitionCode { get; set; }
		public string FromWarehouse { get; set; }

		public string ToWarehouse { get; set; }
		public string DepotCode { get; set; }
		public Nullable<Boolean> IsApproved { get; set; }
		public Nullable<DateTime> ApprovedDate { get; set; }
		public string ApprovedByCode { get; set; }

		public Nullable<Boolean> IsDispatched { get; set; }
		public Nullable<DateTime> DispatchedDate { get; set; }
		public string DispatchByCode{ get; set;}

        public string Remarks { get; set; }

    }
}
