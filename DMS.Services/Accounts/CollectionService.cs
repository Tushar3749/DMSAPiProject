
using DMS.Core.DTO.Accounts;
using DMS.Core.Models.Accounts;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DMS.Core.Models.SummaryInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.DTO;
using DMS.Core.DTO.Report;

namespace DMS.Services.Accounts
{
   
    public class CollectionService : LoggerService, ICollectionService
    {
        private readonly CollectionRepository repo = null;
        private readonly DbContext context;
        public Exception Error = new Exception();

        public CollectionService(IConfiguration Config)
        {
            this.context = new SummaryInvoiceContext(Config);
            this.repo = new CollectionRepository(this.context);
        }

        public async Task<List<SummaryCollectionMoneyReceipt>> getSumCollMoneyReceiptPending()
        {
            return await repo.getSumCollMoneyReceiptPending();
        }

        public async Task<object> getSumCollMoneyReceiptDetail(string collectionCode)
        {
            var collInvoice = await repo.getSumCollMoneyReceiptDetail(collectionCode);
            var collInstrument = await repo.getSumCollMoneyReceiptInstrument(collectionCode);

            return new { CollectionInvoice = collInvoice, CollectionInstrument = collInstrument };
        }


        public async Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetween(string FromDate, string ToDate)
        {
             return await repo.getSumCollDateBetween(FromDate, ToDate);
        }

        public async Task<List<SummaryCollectionByDACodeDto>> getSummaryCollectionByDACode(string FromDate, string ToDate, string DACode)
        {
           
                return await repo.getSummaryCollectionByDACode(FromDate, ToDate, DACode);

        }


        public async Task<List<SummaryCollectionByCodeDto>> getSummaryCollectionByCode(string Code)
        {
           
                return await repo.getSummaryCollectionByCode(Code);
     
        }
        public async Task<List<RegionDTO>> getRegionList()
        {

            return await repo.getRegionList();

        }
        public async Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetweenAndRegion(string FromDate, string ToDate,string RegionCode, string AreaCode, string TerritoryCode)
        {

            if (!string.IsNullOrEmpty(TerritoryCode) && TerritoryCode != "0")
            {
                return await repo.getSumCollDateBetweenAndRegion(FromDate, ToDate, "0", "0", TerritoryCode);

            }

            else if (!string.IsNullOrEmpty(AreaCode) && AreaCode != "0")
            {
                return await repo.getSumCollDateBetweenAndRegion(FromDate, ToDate, "0", AreaCode, "0");

            }

            else
            {
                return await repo.getSumCollDateBetweenAndRegion(FromDate, ToDate, RegionCode, "0", "0");

            }
        }

    }
}
