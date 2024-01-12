using DMS.Core.DTO.DayOperation;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DMS.Services
{
    public class DepoDayStatementService: IDepoDayStatementService
    {
        //Added By Siam
        //Added on 4 JULY 2021
        // UPDATED BY : MEHEDI, NOV 27 2021

        public Exception Error;
        public DepoDayStatementRepository repo;
        private DbContext context;
        public DepoDayStatementService(IConfiguration Config)
        {
            context = new InvoiceContext(Config);
            repo = new DepoDayStatementRepository(context);
        }

        public async Task<DepotDayOperationStatusDto> getDepotDayOperationStatus()
        {
            List<DepotDayOperationStatusDto> data = await repo.getDepotDayOperationStatus();
            return data.FirstOrDefault();          
        }

        public async Task<DepotDayOperationStatusDto> updateDepotDayOperationStatus(string EmployeeCode, Boolean IsReOpen)
        {
            await repo.updateDepotDayOperationStatus(EmployeeCode, IsReOpen);
            return await getDepotDayOperationStatus();
        }

        public async Task<bool> ProcessDayClosing(string ReportDate)
        {
            return await runDayClosingProcess(ReportDate);
        }

        private async Task<bool> runDayClosingProcess(string ReportDate)
        {
            await repo.getDepotClosingStock(ReportDate);

            return true;
        }

        public async Task<bool> ProcessReportData()
        {
            return await repo.ProcessReportData();
        }

        public async Task<DepoInfoDto> getDepoInfoByCode(string depoCode)
        {
            var info =  await repo.getDepoInfoByCode(depoCode);
            return info.FirstOrDefault();
        }

    }
}
