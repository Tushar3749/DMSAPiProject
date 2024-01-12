using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class InvoiceWisePayment
    {
        public string InvoiceCode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsChequeClear { get; set; }
        public DateTime? ChequeClearanceDate { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
