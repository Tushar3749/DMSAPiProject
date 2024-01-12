using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class Deposit
    {
        public int Id { get; set; }
        public string DepositCode { get; set; }
        public string DepotCode { get; set; }
        public DateTime DepositDate { get; set; }
        public string DepositByCode { get; set; }
        public string BankCode { get; set; }
        public string DepositBranch { get; set; }
        public string AccountCode { get; set; }
        public decimal NetDepositAmount { get; set; }
        public string CashReceivedByCode { get; set; }
        public string Remarks { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string ModuleVersion { get; set; }
        public bool IsTransferred { get; set; }
    }
}
