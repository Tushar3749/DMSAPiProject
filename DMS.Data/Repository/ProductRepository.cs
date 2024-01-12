using Microsoft.EntityFrameworkCore;
using DMS.Core.DTO.SalesOrder;
using DMS.Data.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMS.Core.Models.SalesInvoice;
using DMS.Core.DTO;
using Microsoft.Data.SqlClient;
using DMS.Core.DTO.Chemist;

namespace DMS.Data.Repository
{
    public class ProductRepository
    {
        private GenericRepository<Order> salesOrder = null;
        private DbContext context = null;

        public ProductRepository(DbContext context)
        {
            this.context = context;
            this.salesOrder = new GenericRepository<Order>(context);
        }


        public async Task<List<ProductsDto>> getProducts()
        {
            var result = await this.context.Set<ProductsDto>().FromSqlRaw("exec getProducts").ToListAsync();
            return result;
        }

        public async Task<List<ProductSalesAreaWiseDto>> getProductSalesAreaWise(string FromDate, string ToDate, string LocationCode)
        {
            return await this.context.Set<ProductSalesAreaWiseDto>().FromSqlRaw("getProductSalesAreaWise @FromDate, @ToDate, @LocationCode",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@LocationCode", LocationCode)).ToListAsync();
        }

        // GET 

        public async Task<List<ChemistTerritoryHistoryDto>> getChemistTerritoryHistory(string FromDate, string ToDate, string SearchText)
        {
            var getDAList = await this.context.Set<ChemistTerritoryHistoryDto>().FromSqlRaw("exec getDeliveryAssistantWiseReturnQuantity @FromDate, @ToDate, @SearchText",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@SearchText", SearchText)).ToListAsync();
            return getDAList;
        }


    }
}
