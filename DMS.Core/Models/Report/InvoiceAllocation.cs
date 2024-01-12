using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class InvoiceAllocation
    {
        public int Id { get; set; }
        public string AllocationCode { get; set; }
        public DateTime AllocationDate { get; set; }
        public string Dacode { get; set; }
        public string DepotCode { get; set; }
        public DateTime ReturnDate { get; set; }
        public string MachineId { get; set; }
        public bool IsDispatched { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DispatchedById { get; set; }
        public DateTime? DispatchedOn { get; set; }
        public string Remarks { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
