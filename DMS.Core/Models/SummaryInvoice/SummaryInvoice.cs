using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SummaryInvoice
{
    public partial class SummaryInvoice
    {
        public int Id { get; set; }
        public string SummaryCode { get; set; }
        public string InvoiceCode { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountDetailId { get; set; }
        public decimal NetTp { get; set; }
        public decimal NetVat { get; set; }
        public decimal NetProductDiscount { get; set; }
        public decimal NetAmountDiscount { get; set; }
        public decimal CreditNoteAdjustedAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string ReturnType { get; set; }
        public string ReturnReason { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsInvoiceSettled { get; set; }
    }
}
