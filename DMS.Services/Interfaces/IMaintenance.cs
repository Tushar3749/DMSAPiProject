using DMS.Core.DTO.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IMaintenanceService
    {
        Task<List<ValidateSupportTaskRefCodeDto>> getvalidateSupportTaskRefCode(int TaskID, string RefID);
        Task<string> validateDatabaseBackupLog(string ReportDate);
    }
}
