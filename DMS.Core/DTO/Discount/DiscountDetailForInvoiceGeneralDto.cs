using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.Discount
{
    [Keyless]
    public class DiscountDetailForInvoiceGeneralDto
    {
        public string DiscountCode { get; set; }

        public Nullable<decimal> MinimumRange { get; set; }
        public Nullable<decimal> MaximumRange { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<Boolean> IsAmountInPercent { get; set; }
    }
}
