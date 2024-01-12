using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
    [Keyless]
   public class DepositMasterDTO
    {
        public int ID { get; set; }
        public string DepositCode { get; set; }
        public DateTime DepositDate { get; set; }
        public string DepositByCode { get; set; }
        public string BankCode { get; set; }
        public string DepositBranch { get; set; }
        public string AccountCode { get; set; }
        public decimal NetDepositAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsRemitanceConfirmed { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
