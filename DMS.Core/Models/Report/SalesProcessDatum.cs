using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class SalesProcessDatum
    {
        public string DepotCode { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string EmployeeCode { get; set; }
        public string ChemistCode { get; set; }
        public string TerritoryCode { get; set; }
        public string PaymentMode { get; set; }
        public decimal Tp { get; set; }
        public decimal Vat { get; set; }
        public decimal ProductDiscount { get; set; }
        public decimal AmountDiscount { get; set; }
        public decimal Amount { get; set; }
        public string AllocationCode { get; set; }
        public DateTime? AllocationDate { get; set; }
        public string Dacode { get; set; }
        public string SummaryCode { get; set; }
        public DateTime? SummaryDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
