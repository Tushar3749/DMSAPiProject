using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.Maintenance;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public class Maintenance_ModelClasses : DbContext
    {
        public Maintenance_ModelClasses() : base()
        {

        }

        protected virtual DbSet<ValidateSupportTaskRefCodeDto> ValidateSupportTaskRefCodeDto { get; set; }
        protected virtual DbSet<ValidateDatabaseBackupLogDto> ValidateDatabaseBackupLogDto { get; set; }


    }
}
