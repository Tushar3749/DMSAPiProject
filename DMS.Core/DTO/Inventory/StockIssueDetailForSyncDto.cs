using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Inventory
{
    [Keyless]
    public class StockIssueDetailForSyncDto
    {
        public string IssueID { get; set; }

        public string ProductCode { get; set; }
        public string SalesCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string BatchNo { get; set; }
        public Nullable<int> IssueQty { get; set; }
    }
}
