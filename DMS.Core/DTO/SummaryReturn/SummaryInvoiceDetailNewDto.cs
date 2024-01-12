using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.SummaryReturn
{
	[Keyless]
    public class SummaryInvoiceDetailNewDto
    {
        

        public string InvoiceCode { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }

        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public string DiscountCode { get; set; }
        public Nullable<int> InvoiceQty { get; set; }
        public Nullable<int> BonusQty { get; set; }

        public Nullable<decimal> AmountDiscount { get; set; }
        public Nullable<decimal> ProductDiscount { get; set; }
        public Nullable<decimal> TotalTP { get; set; }
        public Nullable<decimal> TotalVAT { get; set; }
        public Nullable<decimal> Amount { get; set; }

        public Nullable<int> ReturnQuantity { get; set; }
        public Nullable<decimal> ReturnAmount { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> SoldAmount { get; set; }

        public string BatchNo { get; set; }

    }
}
