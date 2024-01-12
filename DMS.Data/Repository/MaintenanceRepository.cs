using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.Maintenance;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class MaintenanceRepository : Repository
    {
        private DbContext context = null;
        //public IDbContextTransaction transaction = null;

        public MaintenanceRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        //Added by Siam
        public async Task<List<ValidateSupportTaskRefCodeDto>> validateSupportTaskRefCode(int TaskID, string RefID)
        {

            return await this.context.Set<ValidateSupportTaskRefCodeDto>().FromSqlRaw("validateSupportTaskRefCode @TaskID, @RefID",
                new SqlParameter("@TaskID", TaskID), new SqlParameter("@RefID", RefID)).ToListAsync();
        }

        public async Task<ValidateDatabaseBackupLogDto> validateDatabaseBackupLog(string ReportDate)
        {

            var data= await this.context.Set<ValidateDatabaseBackupLogDto>().FromSqlRaw("validateDatabaseBackupLog @ReportDate",
                new SqlParameter(parameterName: "@ReportDate", ReportDate)
                ).ToListAsync();

            return data.FirstOrDefault();
        }

        //End of Author Siam

    }
}
