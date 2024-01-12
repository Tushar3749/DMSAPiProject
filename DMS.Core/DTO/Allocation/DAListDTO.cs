using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
   public class DAListDTO
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Territory { get; set; }

        public string Mobile { get; set; }
        public Nullable<int> PendingTaskNumber { get; set; }



    }
}
