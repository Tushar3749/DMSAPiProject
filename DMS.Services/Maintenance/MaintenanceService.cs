using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.Maintenance;
using DMS.Core.Models.Maintenance;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Maintenance
{
    public class MaintenanceService: IMaintenanceService
    {
        private readonly MaintenanceRepository repo = null;

        private readonly DbContext context;


        public MaintenanceService(IConfiguration Config)
        {
            this.context = new MaintenanceContext(Config);
            this.repo = new MaintenanceRepository(this.context);
        }

        // GET 

        public async Task<List<ValidateSupportTaskRefCodeDto>> getvalidateSupportTaskRefCode(int TaskID, string RefID)
        {
                return await repo.validateSupportTaskRefCode(TaskID, RefID);
        }

        public async Task<string> validateDatabaseBackupLog(string ReportDate)
        {
            ValidateDatabaseBackupLogDto data = await repo.validateDatabaseBackupLog(ReportDate);
            return data.Message;
        }
    }
}
