using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class DayOpenAndCloseStatement
    {
        public int Id { get; set; }
        public string DepotCode { get; set; }
        public DateTime? ReportDate { get; set; }
        public bool? IsDayOpen { get; set; }
        public string DayOpenByCode { get; set; }
        public DateTime? DayOpenAt { get; set; }
        public bool? IsDayClosed { get; set; }
        public DateTime? DayClosedAt { get; set; }
        public string DayClosedByCode { get; set; }
        public bool IsDateReopened { get; set; }
        public DateTime? ReopenedDate { get; set; }
        public string ReopenedByCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByCode { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedByCode { get; set; }
        public bool IsTransferred { get; set; }
    }
}
