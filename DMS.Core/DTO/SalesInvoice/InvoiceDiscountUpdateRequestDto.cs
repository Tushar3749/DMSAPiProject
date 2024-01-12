using System;
using System.Collections.Generic;

namespace DMS.Core.DTO.SalesInvoice
{
    public class InvoiceDiscountUpdateRequestDto
    {

        public string ChemistCode { get; set; }
        public string PaymentMode { get; set; }
        public Boolean HasCreditNoteAdjustment { get; set; }

        public List<InvoiceDetailNewDto> Details { get; set; }
    }
}
