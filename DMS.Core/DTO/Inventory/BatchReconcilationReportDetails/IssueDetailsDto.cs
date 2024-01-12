using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory.BatchReconcilationReportDetails
{
    [Keyless]
    public class IssueDetailsDto
    {
        public string IssueCode { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueType { get; set; }
        public string TypeName { get; set; }
        public string FromWareHouse { get; set; }
        public string ToWareHouse { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
    }
}
