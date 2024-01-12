using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
   public class StockReceiveDTO
    {
        public int Id { get; set; }
        public string ReceiveCode { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ChallanCode { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedByCode { get; set; }
        
        public int? NoOfProducts { get; set; }

        public int? NoOfBatch { get; set; }

        public string CreatedById { get; set; }

        public string UpdatedById { get; set; }

        public decimal? TP { get; set; }

        public decimal? Vat { get; set; }

        public decimal? TPWithVat { get; set; }
    }
}
