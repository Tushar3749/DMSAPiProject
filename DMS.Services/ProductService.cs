using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class ProductService :  IProductService
    {
        private ProductRepository repo;

        private DbContext context;

        public ProductService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new ProductRepository(this.context);

        }


        public async Task<List<ProductsDto>> getProducts()
        {
            return await repo.getProducts();
        }

        public async Task<List<ProductSalesAreaWiseDto>> getProductSalesAreaWise(string FromDate, string ToDate, string LocationCode)
        {
           
                return await repo.getProductSalesAreaWise(FromDate, ToDate, LocationCode);
        }
        // GET 

        public async Task<List<ChemistTerritoryHistoryDto>> getChemistTerritoryHistory(string FromDate, string ToDate, string SearchText)
        {
            return await repo.getChemistTerritoryHistory(FromDate, ToDate, SearchText);
        }

    }
}
