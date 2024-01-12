using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
   public class StockReceiveDetailsDTO
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
    }
}
