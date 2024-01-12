using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class MoneyReceipt
    {
        public int Id { get; set; }
        public string MoneyReceiptCode { get; set; }
        public DateTime MoneyReceiptDate { get; set; }
        public string SummaryCollectionCode { get; set; }
        public decimal? CashAmount { get; set; }
        public decimal? ChequeAmount { get; set; }
        public decimal Amount { get; set; }
        public string CollectedFromCode { get; set; }
        public bool? IsActive { get; set; }
        public string CanceledById { get; set; }
        public DateTime? CanceledOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ModuleVersion { get; set; }
        public string MachineId { get; set; }
        public bool IsTransferred { get; set; }
        public string DepotCode { get; set; }
        public string Remarks { get; set; }
    }
}
