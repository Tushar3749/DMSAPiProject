using System;

namespace DMS.Core.DTO.SummaryReturn
{
    public class SummaryCollectionDetailNew
    {
        public string InvoiceCode { get; set; }
        public string InvoiceDate { get; set; }
        public string PaymentMode { get; set; }
        public Nullable<decimal> PayableAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> CashCollectionAmount { get; set; }
        public Nullable<decimal> ChequeCollectionAmount { get; set; }
        public Nullable<decimal> CollectionAmount { get; set; }
        public Nullable<decimal> AITDeductionAmount { get; set; }
        public Boolean IsAITDocumentReceived { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> InvoiceDueAmount { get; set; }
    }
}
