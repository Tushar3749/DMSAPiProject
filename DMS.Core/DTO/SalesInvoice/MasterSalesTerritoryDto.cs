using DMS.Core.DTO.SummaryReturn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
   public class MasterSalesTerritoryDto
    {
        public string PaymentMode { get; set; }

        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }
        public string MPOCode { get; set; }
        public string MPOName { get; set; }
        public string AreaID { get; set; }

        public string ASMName { get; set; }
        public string ASMCode { get; set; }

       public List<SalesInvoiceNewDateBetwwen> salesInvoiceDateBetweenDtos { get; set; }
    }
}
