using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class InvoiceProductBatchWise
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public string ProductCode { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
