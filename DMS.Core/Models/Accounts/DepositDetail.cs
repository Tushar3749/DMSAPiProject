using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.Accounts
{
    public partial class DepositDetail
    {
        public int Id { get; set; }
        public string DepositCode { get; set; }
        public string DepositTypeCode { get; set; }
        public decimal? DepositAmount { get; set; }
        public string InstrumentNumber { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public string InstrumentBank { get; set; }
        public string CashReceiveByCode { get; set; }
        public DateTime? CashReceiveByDate { get; set; }
        public bool IsRemitanceConfirmed { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string ConfirmedByCode { get; set; }
        public string ConfirmationRemarks { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsTransferred { get; set; }
    }
}
