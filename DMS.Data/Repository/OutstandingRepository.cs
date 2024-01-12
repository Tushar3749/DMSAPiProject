using DMS.Core.DTO;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.Report.Outstanding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class OutstandingRepository
    {
        //Added By Siam
        //Added on 11 JULY 2021
        private DbContext context = null;

        public OutstandingRepository(DbContext context)
        {
            this.context = context;
           this.context.Database.SetCommandTimeout(240);

        }


        public async Task<List<TerritoryDTO>> GetAllTerritory(string areacode)
        {
            return await this.context.Set<TerritoryDTO>().FromSqlRaw("exec GetAllTerritory @AreaCode"
                , new SqlParameter("@AreaCode", areacode)).ToListAsync();

        }
        public async Task<List<LocationWiseOutstandingDTO>> getOutstandingLocationWise(string LocationCode, string PaymentMode, string Datefrom, string DateTo)
        {
            return await this.context.Set<LocationWiseOutstandingDTO>().FromSqlRaw("getLocationWiseOutstanding  @LocationCode, @PaymentMode, @FromDate, @DateTo",
           
                new SqlParameter("@LocationCode", LocationCode)
                , new SqlParameter("@PaymentMode", PaymentMode)
                , new SqlParameter("@FromDate", Datefrom)
                , new SqlParameter("@DateTo", DateTo)
                ).ToListAsync();
        }
        public async Task<List<LocationWiseOutstandingDetailDto>> getOutstandingLocationWiseDetail(string LocationCode, string SearchByCode,  string PaymentMode, string Datefrom, string DateTo)
        {
            return await this.context.Set<LocationWiseOutstandingDetailDto>().FromSqlRaw("getLocationWiseOutstandingDetail @LocationCode, @SearchByCode, @PaymentMode, @FromDate, @DateTo",
                new SqlParameter("@LocationCode", LocationCode)
                ,new SqlParameter("@SearchByCode", SearchByCode)
                , new SqlParameter("@PaymentMode", PaymentMode)
                , new SqlParameter("@FromDate", Datefrom)
                , new SqlParameter("@DateTo", DateTo)
                ).ToListAsync();
        }
    }
}
