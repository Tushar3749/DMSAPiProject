using DMS.Core.DTO.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Allocation
{
    public class InvoiceAllocationModelDto
    {
        public string DACode { get; set; }
        public string ReturnDate {  get; set; }
        public List<InvoiceAllocationDetailsDTO> AllocationInvoice {  get; set; }
    }
}
