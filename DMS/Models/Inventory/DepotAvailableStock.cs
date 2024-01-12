using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Models.Inventory
{
    public partial class DepotAvailableStock
    {
        public string ProductCode { get; set; }
        public string BatchNo { get; set; }
        public int ReceiveQty { get; set; }
        public int IssueQty { get; set; }
        public int InvoiceQty { get; set; }
        public int SoldQty { get; set; }
        public int ReturnQty { get; set; }
    }
}
