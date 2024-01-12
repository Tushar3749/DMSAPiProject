using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class Summary
    {
        public int Id { get; set; }
        public string SummaryCode { get; set; }
        public DateTime SummaryDate { get; set; }
        public string AllocationCode { get; set; }
        public string MachineId { get; set; }
        public bool IsFinalized { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ModuleVersion { get; set; }
    }
}
