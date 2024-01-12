using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Report
{
    [Keyless]
    public class SalesAndCollectionForDashboardDto
    {
        public Nullable<int> OrderNo { get; set; }

        public string ReportType { get; set; }
        public string ColumnTitle { get; set; }
        public Nullable<decimal> ColumnValue { get; set; }
    }
}
