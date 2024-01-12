using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class SummaryCollection
    {
        public int Id { get; set; }
        public string CollectionCode { get; set; }
        public string SummaryCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
