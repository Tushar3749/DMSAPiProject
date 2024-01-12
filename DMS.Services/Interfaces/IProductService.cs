using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.SalesOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductsDto>> getProducts();
        Task<List<ProductSalesAreaWiseDto>> getProductSalesAreaWise(string FromDate, string ToDate, string LocationCode);
        Task<List<ChemistTerritoryHistoryDto>> getChemistTerritoryHistory(string FromDate, string ToDate, string SearchText);
    }
}
