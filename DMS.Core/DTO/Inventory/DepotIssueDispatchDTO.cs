using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Inventory
{
   public class DepotIssueDispatchDTO
    {
        public Nullable<int> ID { get; set; }

        public string IssueCode { get; set; }
        public Nullable<DateTime> IssueDate { get; set; }
        public string IssueType { get; set; }
        public string FromWarehouse { get; set; }

        public string ToWarehouse { get; set; }

        public int? NoOfProducts { get; set; }
        public int? NoOfBatch { get; set; }

        public string EmployeeName { get; set; }

        public Nullable<DateTime> ApprovedDate { get; set; }

        public Nullable<decimal> TotalTPMaster { get; set; }

        public Nullable<decimal> TotalVATMaster { get; set; }

        public string EmployeeID { get; set; }



    }
}
