using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public class AccountContext_ModelClasses : DbContext
    {
        public AccountContext_ModelClasses() : base()
        {

        }

        protected virtual DbSet<SummaryPendingCollectionDto> SummaryPendingCollectionDto { get; set; }
        protected virtual DbSet<SummaryPendingCollectionDetailDto> SummaryPendingCollectionDetailDto { get; set; }
        protected virtual DbSet<BankListDTO> BankListDTO { get; set; }
        protected virtual DbSet<DepositDTO> DepositDTO { get; set; }
        protected virtual DbSet<DueCollectionChemistWiseDto> DueCollectionChemistWiseDto { get; set; }
        protected virtual DbSet<DueCollectionChemistWiseDetailDto> DueCollectionChemistWiseDetailDto { get; set; }

        protected virtual DbSet<DepositReportDTO> DepositReportDTO { get; set; }
        protected virtual DbSet<DepositDetailReportDTO> DepositDetailReportDTO { get; set; }
        protected virtual DbSet<DepositDetailDTO> DepositDetailDTO { get; set; }

        protected virtual DbSet<MoneyReceiptDto> MoneyReceiptDto { get; set; }
        protected virtual DbSet<MoneyReceiptDateWiseDto> MoneyReceiptDateWiseDto { get; set; }

        public virtual DbSet<GenerateCodeDTO> GenerateCodeDTO { get; set; }
        public virtual DbSet<InstrumentInfoDto> InstrumentInfoDto { get; set; }

        protected virtual DbSet<Location> Location { get; set; }
        protected virtual DbSet<LocationWiseCollectionReportDTO> LocationWiseCollectionReportDTO { get; set; }
    }
}
