using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DMS.Core.DTO.SalesOrder;
using DMS.Data.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.DTO;

namespace DMS.Data.Repository
{
    public class CollectionRepository
    {
        private DbContext context = null;

        public CollectionRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<List<SummaryCollectionMoneyReceipt>> getSumCollMoneyReceiptPending()
        {
            return await new GenericRepository<SummaryCollectionMoneyReceipt>(context).FindUsingSPAsync("exec getSummaryCollectionMoneyReceiptPending");
        }

        public async Task<List<SummaryCollectionMoneyReceiptDetail>> getSumCollMoneyReceiptDetail(string collectionCode)
        {
            return await this.context.Set<SummaryCollectionMoneyReceiptDetail>().FromSqlRaw("exec getSummaryCollectionMoneyReceiptDetail @CollectionCode", new SqlParameter("@CollectionCode", collectionCode)).ToListAsync();
        }

        public async Task<List<SummaryCollectionMoneyReceiptInstrument>> getSumCollMoneyReceiptInstrument(string collectionCode)
        {
            return await this.context.Set<SummaryCollectionMoneyReceiptInstrument>().FromSqlRaw("exec getSummaryCollectionMoneyReceiptInstrument @CollectionCode", new SqlParameter("@CollectionCode", collectionCode)).ToListAsync();
        }

        public async Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetween(string FromDate, string ToDate)
        {
            return await this.context.Set<SummaryCollectionsDateBetween>().FromSqlRaw("exec getSummaryCollectionDateWise @FromDate, @ToDate", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }

        public async Task<List<SummaryCollectionByDACodeDto>> getSummaryCollectionByDACode(string FromDate, string ToDate, string DACode)
        {
            return await this.context.Set<SummaryCollectionByDACodeDto>().FromSqlRaw("getSummaryCollectionByDACode @FromDate, @ToDate, @DACode",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@DACode", DACode)).ToListAsync();
        }

        public async Task<List<SummaryCollectionByCodeDto>> getSummaryCollectionByCode(string Code)
        {
            return await this.context.Set<SummaryCollectionByCodeDto>().FromSqlRaw("getSummaryCollectionByCode @Code",
                new SqlParameter("@Code", Code)).ToListAsync();
        }

        public async Task<List<RegionDTO>> getRegionList()
        {
            return await new GenericRepository<RegionDTO>(context).FindUsingSPAsync("exec getAllRegion");

        }
          public async Task<List<SummaryCollectionsDateBetween>> getSumCollDateBetweenAndRegion(string FromDate, string ToDate,string RegionCode, string AreaCode, string TerritoryCode)
        {
            return await this.context.Set<SummaryCollectionsDateBetween>().FromSqlRaw("exec getSummaryCollectionRegionAndDateWise @FromDate, @ToDate,@RegionCode,@AreaCode,@TerritoryCode", new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@RegionCode", RegionCode), new SqlParameter("@AreaCode", AreaCode), new SqlParameter("@TerritoryCode", TerritoryCode)).ToListAsync();
        }

    }
}
