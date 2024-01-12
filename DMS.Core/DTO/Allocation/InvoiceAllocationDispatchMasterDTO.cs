using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.SalesInvoice
{
    [Keyless]
   public class InvoiceAllocationDispatchMasterDTO
    {
        public string InvoiceCode { get; set; }

        public string ChemistName { get; set; }

        public List<InvoiceAllocationDispatchDTO> InvoiceAllocationDispatchDTO { get; set; }

    }
}
