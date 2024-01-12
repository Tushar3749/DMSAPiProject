using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.SalesInvoice
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string OrderCode { get; set; }
        public string ChemistCode { get; set; }
        public string Mpocode { get; set; }
        public string TerritoryCode { get; set; }
        public string DepotCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string PaymentMode { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountDetailId { get; set; }
        public decimal NetTp { get; set; }
        public decimal NetVat { get; set; }
        public decimal NetProductDiscount { get; set; }
        public decimal NetAmountDiscount { get; set; }
        public decimal CreditNoteAdjustedAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsInvoiceAllocated { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsInvoiceSettled { get; set; }
    }
}
