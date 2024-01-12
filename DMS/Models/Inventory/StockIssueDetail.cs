using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Models.Inventory
{
    public partial class StockIssueDetail
    {
        public int Id { get; set; }
        public string IssueCode { get; set; }
        public string BatchNo { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public bool? IsActive { get; set; }
        public string MachineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        public bool IsTransferred { get; set; }
    }
}
