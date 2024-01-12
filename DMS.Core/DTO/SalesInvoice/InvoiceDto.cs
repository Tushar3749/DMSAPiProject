using System.Collections.Generic;

namespace DMS.Core.DTO.SalesInvoice
{
    public class InvoiceDto
    {
        public InvoiceMasterDto Invoice { get; set; }
        public List<InvoiceDetailNewDto> Detail { get; set; }
    }
}
