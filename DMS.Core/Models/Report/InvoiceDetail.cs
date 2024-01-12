using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class InvoiceDetail
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public string ProductCode { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public int Sps { get; set; }
        public decimal Tp { get; set; }
        public decimal Vat { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountDetailId { get; set; }
        public int InvoiceQty { get; set; }
        public int BonusQty { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal TotalTp { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal TotalAmountDiscount { get; set; }
        public decimal TotalProductDiscount { get; set; }
        public decimal Amount { get; set; }
        public bool? IsInvoiceDiscountApplicable { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
