using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Accounts
{
    
   public class DepositDetailReportDTO
    {
        public int ID { get; set; }
        public string DepositCode { get; set; }
        public string DepositTypeCode { get; set; }
        public decimal? DepositAmount { get; set; }
        public string InstrumentNumber { get; set; }
        public DateTime? InstrumentDate { get; set; }
        public string InstrumentBank { get; set; }
        public string CashReceiveByCode { get; set; }
        public DateTime? CashReceiveByDate { get; set; }
        public string MachineId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
