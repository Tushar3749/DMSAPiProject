using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Inventory
{
    public partial class StockIssue
    {
        public int Id { get; set; }
        public string IssueCode { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueType { get; set; }
        public string RequisitionCode { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public string DepotCode { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedByCode { get; set; }
        public bool IsDispatched { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public string DispatchByCode { get; set; }
        public string Remarks { get; set; }
        public bool? IsActive { get; set; }
        public string MachineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
