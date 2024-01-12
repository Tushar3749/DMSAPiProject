using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
   [Keyless]
   public class DepositDTO
   {
        public string BankCode { get; set; }
        public string CashReceivedbyCode { get; set; }

        public string DepositType { get; set; }
        public decimal? DepositAmount { get; set; }
        public string ChequeNumber { get; set; }
        public string ChequeDate { get; set; }
        public string ChequeBank { get; set; }

        public string DepositCode { get; set; }

        public string DepositTypeCode { get; set; }
        public string InstrumentNumber { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public string InstrumentBank { get; set; }
        public string CashReceiveByCode { get; set; }
        public DateTime? CashReceiveByDate { get; set; }
        public string MachineID { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Remarks { get; set; }
        public decimal TotalDepositAmount { get; set; }

        public int? Id { get; set; }
        public string Branch { get; set; }
    }
}
