using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class DiscountRepository
    {
        private DbContext context = null;

        public DiscountRepository(DbContext context)
        {
            this.context = context;

        }


        //Author Shamsul Hasan Siam 18 june
        //public async Task<List<DiscountBySearchDto>> getDiscountBySearch(string DepoID, string ProductID, string RateMinimum, string RateMaximum, int DiscountTypeID, string SearchByName, int ActiveStatus)
        //{
        //    var result = await this.context.Set<DiscountBySearchDto>().FromSqlRaw("getDiscountBySearch @DepoID, @ProductID, @RateMinimum, @RateMaximum, @DiscountTypeID, @SearchByName, @ActiveStatus",
        //       new SqlParameter("@DepoID", DepoID), new SqlParameter("@ProductID", ProductID), new SqlParameter("@RateMinimum", RateMinimum), new SqlParameter("@RateMaximum", RateMaximum), new SqlParameter("@DiscountTypeID", DiscountTypeID), new SqlParameter("@SearchByName", SearchByName), new SqlParameter("@ActiveStatus", ActiveStatus)).ToListAsync();
        //    return result;
        //}

        public async Task<List<DiscountBySearchDto>> getDiscountBySearch(string LocationCode, string ProductCode, string SearchText)
        {
               var result = await this.context.Set<DiscountBySearchDto>().FromSqlRaw("getDiscountBySearch @LocationCode, @ProductCode, @SearchText",
                 new SqlParameter("@LocationCode", LocationCode), new SqlParameter("@ProductCode", ProductCode), new SqlParameter("@SearchText", SearchText)).ToListAsync();
            return result;
        }

        /*
        *=============================================
        * END Of Author Shamsul Hasan Siam
        *=============================================
        */

        public async Task<List<DiscountDetailForInvoiceGeneralDto>> getTradeDiscountDetail()
        {
            var data = await this.context.Set<DiscountDetailForInvoiceGeneralDto>().FromSqlRaw("getDiscountDetailForInvoiceGeneral ").ToListAsync();
            return data;
        }


        public async Task<DiscountReportDto> getDiscountReportMaster(string DiscountID)
        {
            var data = await this.context.Set<DiscountReportDto>().FromSqlRaw("getDiscountReport @DiscountID, 'MASTER'",
                new SqlParameter("@DiscountID", DiscountID)).ToListAsync();

            return data.FirstOrDefault();
        }

        public async Task<List<DiscountDetailDto>> getDiscountReportDetails(string DiscountID)
        {
            var data = await this.context.Set<DiscountDetailDto>().FromSqlRaw("getDiscountReport @DiscountID, 'DETAIL'",
                new SqlParameter("@DiscountID", DiscountID)).ToListAsync();
            return data;
        }
    }
}
