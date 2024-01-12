using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.SummaryReturn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
   public interface ICollectionService
    {
        Task<List<SummaryCollectionMoneyReceipt>> getSumCollMoneyReceiptPending();
        Task<object> getSumCollMoneyReceiptDetail(string collectionCode);
        Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetween(string FromDate, string ToDate);
        Task<List<SummaryCollectionByDACodeDto>> getSummaryCollectionByDACode(string FromDate, string ToDate, string DACode);
        Task<List<SummaryCollectionByCodeDto>> getSummaryCollectionByCode(string Code);
        Task<List<RegionDTO>> getRegionList();
        Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetweenAndRegion(string FromDate, string ToDate, string RegionCode, string AreaCode, string TerritoryCode);
    }
}
