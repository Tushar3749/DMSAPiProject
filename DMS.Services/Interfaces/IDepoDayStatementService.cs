using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.DayOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    //Added By Siam
    //Added on 4 JULY 2021
    public interface IDepoDayStatementService
    {
        Task<DepotDayOperationStatusDto> getDepotDayOperationStatus();
        Task<DepotDayOperationStatusDto> updateDepotDayOperationStatus(string EmployeeCode, Boolean IsReOpen);
        Task<bool> ProcessDayClosing(string ReportDate);
        Task<bool> ProcessReportData();
        Task<DepoInfoDto> getDepoInfoByCode(string depoCode);
    }
}
