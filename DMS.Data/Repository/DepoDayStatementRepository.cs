using DMS.Core.DTO;
using DMS.Core.DTO.DayOperation;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DMS.Data.Repository
{
    public class DepoDayStatementRepository
    {
        //Added By Siam
        //Added on 4 JULY 2021
        private DbContext context = null;

        public DepoDayStatementRepository(DbContext context)
        {
            this.context = context;

        }


        public async Task<List<DepotDayOperationStatusDto>> getDepotDayOperationStatus()
        {
            var data = await this.context.Set<DepotDayOperationStatusDto>().FromSqlRaw("getDepotDayOperationStatus").ToListAsync();
            return data;
        }


        public async Task<Boolean> updateDepotDayOperationStatus(string EmployeeCode, Boolean IsReOpen = false)
        {
            await this.context.Set<GeneratedCode>().FromSqlRaw("updateDepotDayOperationStatus @EmployeeID, @IsReOpen",
                new SqlParameter("@EmployeeID", EmployeeCode),
                new SqlParameter("@IsReOpen", IsReOpen)
                ).ToListAsync();                
            return true;
        }



        public async Task<bool> getDepotClosingStock(string ReportDate)
        {
            await new GenericRepository<Invoice>(this.context).ExecuteCommand("exec Inventory_DMS.dbo.getDepotClosingStock @closingDate", new SqlParameter("@closingDate", ReportDate));
            return true;
        }

        public async Task<bool> ProcessReportData()
        {
            await new GenericRepository<Invoice>(this.context).ExecuteCommand("EXEC ProcessReportData ");
            return true;
        }

        public async Task<IEnumerable<DepoInfoDto>> getDepoInfoByCode(string depoCode)
        {
            var result = await this.context.Set<DepoInfoDto>().FromSqlRaw("exec getDepoInfoByCode @DepoCode",
                new SqlParameter("@DepoCode", depoCode)).ToListAsync();
            return result;
        }
    }
}
