using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class SummaryCollectionDetail
    {
        public int Id { get; set; }
        public string CollectionCode { get; set; }
        public string InvoiceCode { get; set; }
        public string PaymentMode { get; set; }
        public decimal? CashCollectionAmount { get; set; }
        public decimal? ChequeCollectionAmount { get; set; }
        public decimal Amount { get; set; }
        public string InstrumentNumber { get; set; }
        public decimal? AitdeductionAmount { get; set; }
        public bool? IsAitdocumentReceived { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
