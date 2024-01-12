using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class InvoiceWiseCollection
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string DepotCode { get; set; }
        public string PaymentMode { get; set; }
        public decimal InvoiceTp { get; set; }
        public decimal InvoiceVat { get; set; }
        public decimal InvoiceAmountDiscount { get; set; }
        public decimal InvoiceProductDiscount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string ChemistCode { get; set; }
        public string TerritoryCode { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
