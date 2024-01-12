using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Models.Inventory
{
    public partial class StockReceiveDetail
    {
        public int Id { get; set; }
        public string ReceiveCode { get; set; }
        public string BatchNo { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
        public string MachineId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedById { get; set; }
        public bool IsTransferred { get; set; }
    }
}
