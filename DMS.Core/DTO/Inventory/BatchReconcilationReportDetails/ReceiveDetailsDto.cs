using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory.BatchReconcilationReportDetails
{
    [Keyless]
    public class ReceiveDetailsDto
    {
        public string ReceiveCode { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string ReceiveType { get; set; }
        public string ChallanCode { get; set; }
        public string FromWareHouse { get; set; }
        public string ToWareHouse { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public string BatchNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
    }
}
