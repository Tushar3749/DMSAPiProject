using DMS.Core.DTO;
using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SummaryInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class SummaryRepository : Repository
    {
        private GenericRepository<SummaryInvoice> repo = null;
        private DbContext context = null;

        public IDbContextTransaction transaction = null;


        public SummaryRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.repo = new GenericRepository<SummaryInvoice>(this.context);
            this.context.Database.SetCommandTimeout(240);

        }

        public async Task<Boolean> BEGIN_TRANSACTION()
        {
            this.transaction = await this.context.Database.BeginTransactionAsync();
            return true;
        }

        public async Task<Boolean> COMMIT()
        {
            if (this.transaction != null) await this.transaction.CommitAsync();
            return true;
        }

        public async Task<Boolean> ROLL_BACK()
        {
            if (this.transaction != null) await this.transaction.RollbackAsync();
            return true;
        }

        public async Task<List<AllocationInvoiceForSummaryDto>> getAllocationInvoiceForSummary(string AllocationCode)
        {
            var data = await this.context.Set<AllocationInvoiceForSummaryDto>().FromSqlRaw("getAllocationInvoiceForSummary @AllocationCode",
                new SqlParameter("@AllocationCode", AllocationCode)).ToListAsync();
            return data;
        }

        public async Task<List<SummaryInvoiceDetailNewDto>> getSummaryInvoiceDetailForSummary(string AllocationCode)
        {
            var data = await this.context.Set<SummaryInvoiceDetailNewDto>().FromSqlRaw("getAllocationInvoiceForSummary @AllocationCode, 'DETAIL'",
               new SqlParameter("@AllocationCode", AllocationCode)).ToListAsync();
            return data;
        }


        public async Task<List<InvoiceReturnTypeDto>> getInvoiceReturnType()
        {
            var data = await this.context.Set<InvoiceReturnTypeDto>().FromSqlRaw("getInvoiceReturnType ").ToListAsync();
            return data;
        }


        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode,string Status)
        {
            var data = await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesInvoiceDateBetween @FromDate, @ToDate, @PaymentMode, @Status",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@PaymentMode", PaymentMode),new SqlParameter("@Status", Status)).ToListAsync();
            return data;
        }

        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByTerritoryORMpo(string FromDate, string ToDate, string Code, string PaymentMode)
        {
            return await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesInvoiceByTerritoryORMpo @FromDate, @ToDate, @Code, @PaymentMode",
        new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@Code", Code), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
        }

        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesInvoiceByCode(string Code)
        {
            return await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesInvoiceByCode @Code",
                new SqlParameter("@Code", Code)).ToListAsync();
        }
        public async Task<List<SalesInvoiceNewDateBetwwen>> getSalesReportDateBetween(OutstandingDto outstandingDto)

        {
            try
            {
                return await this.context.Set<SalesInvoiceNewDateBetwwen>().FromSqlRaw("getSalesReportDateBetween @FromDate, @ToDate, @Code, @PaymentMode",
               new SqlParameter("@FromDate", outstandingDto.FromDate), new SqlParameter("@ToDate", outstandingDto.ToDate), new SqlParameter("@Code", outstandingDto.Code), new SqlParameter("@PaymentMode", outstandingDto.PaymentMode)).ToListAsync();
            }
            catch (Exception e)
            {
                return null;

            }
        }
        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesDateBetween(string FromDate, string ToDate, string PaymentMode)
        {
            var data = await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesDateBetween @FromDate, @ToDate, @PaymentMode",
          new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
            return data;
        }
        public async Task<List<MasterSalesTerritoryDto>> getMasterSalesTerritory(OutstandingDto outstandingDto)
        {
            
             return await this.context.Set<MasterSalesTerritoryDto>().FromSqlRaw("getMasterSalesTerritory @FromDate, @ToDate, @Code, @PaymentMode",
             new SqlParameter("@FromDate", outstandingDto.FromDate), new SqlParameter("@ToDate", outstandingDto.ToDate), new SqlParameter("@Code", outstandingDto.Code), new SqlParameter("@PaymentMode", outstandingDto.PaymentMode)).ToListAsync();
           
        }
        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByMPOTerritory(string FromDate, string ToDate, string Code, string PaymentMode)
        {
            return await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesByMPOTerritory @FromDate, @ToDate, @Code, @PaymentMode",
        new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@Code", Code), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
        }
        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByCode(string Code)
        {
            return await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesByCode @Code",
                new SqlParameter("@Code", Code)).ToListAsync();
        }
        public async Task<List<SalesInvoiceDateBetweenDto>> getSalesByArea(string FromDate, string ToDate, string AreaID,string PaymentMode)
        {
            return await this.context.Set<SalesInvoiceDateBetweenDto>().FromSqlRaw("getSalesByArea @FromDate, @ToDate, @AreaID, @PaymentMode",
        new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@AreaID", AreaID), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
        }
        public async Task<List<RegionDTO>> getRegionList()
        {
            var data = await this.context.Set<RegionDTO>().FromSqlRaw("getRegion").ToListAsync();
            return data;

        }
        public async Task<List<AreaDto>> getArea()
        {
            return await this.context.Set<AreaDto>().FromSqlRaw("getArea").ToListAsync();
        }
        public async Task<List<BatchWiseReturnDto>> getBatchWiseReturn(string FromDate, string ToDate)
        {
            return await this.context.Set<BatchWiseReturnDto>().FromSqlRaw("getBatchWiseReturn @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }
        public async Task<List<ProductWiseReturnDto>> getProductWiseReturn(string FromDate, string ToDate)
        {
            return await this.context.Set<ProductWiseReturnDto>().FromSqlRaw("getProductWiseReturn @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }
        //PRODUCT WISE MPO-AM-RM REPORT
        public async Task<List<ProductWiseSalesDto>> getTerritoryWiseAllProductSales(string FromDate, string ToDate , string AreaCode)
        {
            var result = await this.context.Set<ProductWiseSalesDto>().FromSqlRaw("getTerritoryWiseAllProductSales @FromDate, @ToDate ,@AreaCode",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@AreaCode", AreaCode)).ToListAsync();
            return result;
        }
        public async Task<List<RegionDTO>> getAllAreaCodeByRegion(string RegionCode)
        {
            return await this.context.Set<RegionDTO>().FromSqlRaw("getAllAreaCodeByRegion @RegionCode"
               , new SqlParameter("@RegionCode", RegionCode)).ToListAsync();
        }
        public async Task<List<TerritoryDTO>> getAllTerritoryCodeByArea(string AreaCode)
        {
            return await this.context.Set<TerritoryDTO>().FromSqlRaw("getAllTerritoryCodeByArea @AreaCode"
               , new SqlParameter("@AreaCode", AreaCode)).ToListAsync();
        }

        public async Task<List<ProductWiseSalesMasterDetailDTO>> getProductWiseSales(string FromDate, string ToDate)
        {
            return await this.context.Set<ProductWiseSalesMasterDetailDTO>().FromSqlRaw("getProductWiseReturn @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
        }

        public async Task<bool> updateDepotSoldAvailableStock()
        {
            return await new GenericRepository<Summary>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotSoldQuantityToAvailableStock");
        }




    }
}
