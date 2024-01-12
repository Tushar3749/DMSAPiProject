using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class SummaryInvoiceProductBatchWise
    {
        public int Id { get; set; }
        public string SummaryCode { get; set; }
        public string InvoiceCode { get; set; }
        public string ProductCode { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public int SoldQty { get; set; }
        public int ReturnQty { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
