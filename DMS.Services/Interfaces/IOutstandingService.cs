using DMS.Core.DTO;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.Report.Outstanding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IOutstandingService
    {

        Task<List<TerritoryDTO>> GetAllTerritory(string areacode);
     
        Task<List<LocationWiseOutstanding>> getInvoiceOutstandingLocationWise(string LocationCode, string PaymentMode, string Datefrom, string DateTo);

        Task<List<LocationWiseOutstandingDetail>> getOutstandingLocationWiseDetail(string LocationCode, string SearchByCode, string PaymentMode, string Datefrom, string DateTo);
        Task<List<LocationWiseOutstandingDTO>> getOutstandingLocationWiseForExcel(string LocationCode, string PaymentMode, string FromDate, string DateTo);
        Task<List<LocationWiseOutstandingDetailDto>> getLocationWiseOutstandingDetailForExcel(string LocationCode, string SearchByCode, string PaymentMode, string FromDate, string DateTo);
    }
}
