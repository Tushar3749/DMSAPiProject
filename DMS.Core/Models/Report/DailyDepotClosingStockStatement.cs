using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Report
{
    public partial class DailyDepotClosingStockStatement
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string DepotCode { get; set; }
        public DateTime ReportDate { get; set; }
        public int ReceiveApprovalPendingQuantity { get; set; }
        public int ReceivePendingQuantity { get; set; }
        public int ReceiveQuantity { get; set; }
        public int IssueApprovalPendingQuantity { get; set; }
        public int IssuePendingQuantity { get; set; }
        public int IssueQuantity { get; set; }
        public int InvoicePendingAllocationQuantity { get; set; }
        public int InvoiceAllocationPendingDispatchQuantity { get; set; }
        public int InvoiceDispatchQuantity { get; set; }
        public int SummaryFinalizePendingQuantity { get; set; }
        public int TransitQuantity { get; set; }
        public int SummaryTransitQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public int ReturnQuantity { get; set; }
        public int AvailableStock { get; set; }
        public int PhysicalStock { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
