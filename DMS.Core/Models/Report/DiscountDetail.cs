using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class DiscountDetail
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public string ProductCode { get; set; }
        public decimal? MinimumInvoiceAmount { get; set; }
        public decimal? MinimumRange { get; set; }
        public decimal? MaximumRange { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMode { get; set; }
        public bool? IsInvoiceReturnable { get; set; }
        public bool IsAmountInPercent { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsTransferred { get; set; }

        public virtual Discount DiscountCodeNavigation { get; set; }
    }
}
