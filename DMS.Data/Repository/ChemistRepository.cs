using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Discount;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.Models.SalesMaster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DMS.Data.Repositories.GenericRepository;
using System;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.PartyCode;
using DMS.Core.Models.Inventory;
using DMS.Core.Models.SalesInvoice;

namespace DMS.Data.Repository
{
    public class ChemistRepository : Repository
    {
        private DbContext context = null;

        public ChemistRepository(DbContext context) : base(context)
        {
            this.context = context;
           
        }
        public async Task<List<Chemist>> getLabaidEmployeeChemist(string ChemistID)
        {
            var result = await this.context.Set<Chemist>().FromSqlRaw("exec getLabaidEmployeeChemist @ChemistID", new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<ChemistsDto>> getChemists(string EmployeeID)
        {
            var result = await this.context.Set<ChemistsDto>().FromSqlRaw("exec getChemists @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID)).ToListAsync();
            return result;
        }
        
        public async Task<List<ChemistDetailDto>> getChemistProfile(string ChemistID)
        {
            var result = await this.context.Set<ChemistDetailDto>().FromSqlRaw("getChemistProfile @ChemistID,'MASTER'",
                new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }
        public async Task<List<ChemistBusinessProfileDto>> getChemistBusinessProfile(string ChemistID)
        {
            var result = await this.context.Set<ChemistBusinessProfileDto>().FromSqlRaw("getChemistProfile @ChemistID,'BUSINESS'",
                new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }
        public async Task<List<ChemistCreditProfileDto>> getChemistCreditProfile(string ChemistID)
        {
            var result = await this.context.Set<ChemistCreditProfileDto>().FromSqlRaw("getChemistProfile @ChemistID,'CREDIT'",
                new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }

        public async Task<List<ChemistCreditDuesDto>> getChemistCreditDuesProfile(string ChemistID)
        {
            var result = await this.context.Set<ChemistCreditDuesDto>().FromSqlRaw("getChemistProfile @ChemistID,'CREDIT_DUES'",
                new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }

        public async Task<List<ChemistType>> getChemistTypeNames()
        {
            var result = await new GenericRepository<ChemistType>(this.context).GetAll();
            return result;
        }




        public async Task<List<ChemistDiscountDto>> getChemistDiscountProfile(string ChemistID)
        {
            var result = await this.context.Set<ChemistDiscountDto>().FromSqlRaw("getChemistProfile @ChemistID,'DISCOUNT'",
                new SqlParameter("@ChemistID", ChemistID)).ToListAsync();
            return result;
        }

        public async Task<List<ChemistCreditStatusDto>> getChemistCreditStatus(string ChemistCode)
        {
            var result = await this.context.Set<ChemistCreditStatusDto>().FromSqlRaw("getChemistCreditStatus @ChemistCode",
                new SqlParameter("@ChemistCode", ChemistCode)).ToListAsync();
            return result;
        }


        //Added By Siam
        //Added on 10 JULY 2021
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getChemistDueInvoiceForSummary(string ChemistCode)
        {
           
            var result = await this.context.Set<ChemistDueInvoiceForSummaryDto>().FromSqlRaw("getChemistDueInvoiceForSummary @ChemistCode",
                new SqlParameter("@ChemistCode", ChemistCode)).ToListAsync();
            return result;


        }
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getSummaryDueInvoiceForSummary(string SummaryCode)
        {

            var result = await this.context.Set<ChemistDueInvoiceForSummaryDto>().FromSqlRaw("getSummaryDueInvoiceForSummary @SummaryCode",
                new SqlParameter("@SummaryCode", SummaryCode)).ToListAsync();
            return result;


        }
        public async Task<List<ChemistDueInvoiceForSummaryDto>> getMPODueInvoiceForSummary(string MPOCode)
        {

            var result = await this.context.Set<ChemistDueInvoiceForSummaryDto>().FromSqlRaw("getMPODueInvoiceForSummary @MPOCode",
                new SqlParameter("@MPOCode", MPOCode)).ToListAsync();
            return result;


        }
        public async Task<List<MPODueDTO>> getAllMPODue()
        {

            var result = await this.context.Set<MPODueDTO>().FromSqlRaw("getAllMPODue").ToListAsync();
            return result;


        }
        public async Task<List<ChemistBySearchDto>> getChemistBySearch(string LocationCode, string ChemistTypeCode, string SearchText)
        {
            var result = await this.context.Set<ChemistBySearchDto>().FromSqlRaw("getChemistBySearch @LocationCode, @ChemistTypeCode, @SearchText",
                new SqlParameter("@LocationCode", LocationCode), new SqlParameter("@ChemistTypeCode", ChemistTypeCode), new SqlParameter("@SearchText", SearchText)).ToListAsync();
            return result;
        }


        public async Task<List<ChemistBusinessDateWiseDto>> getChemistBusinessDateWise(string FromDate, string ToDate, string ChemistCode)
        {
            return await this.context.Set<ChemistBusinessDateWiseDto>().FromSqlRaw("getChemistBusinessDateWise @FromDate, @ToDate, @ChemistCode",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate), new SqlParameter("@ChemistCode", ChemistCode)).ToListAsync();
        }

        public async Task<Chemist> saveChemist(Chemist Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<Chemist>(this.context).Insert(Entity);
        }

        public async Task<ChemistCredit> saveChemistCredit(ChemistCredit Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<ChemistCredit>(this.context).Insert(Entity);
        }

        public async Task<ChemistTerritory> saveChemistTerritory(ChemistTerritory Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<ChemistTerritory>(this.context).Insert(Entity);
        }

        //Added by Siam
        public async Task<List<MarketByTerritoryDto>> getMarketByTerritory(string TerritoryCode)
        {
            return await this.context.Set<MarketByTerritoryDto>().FromSqlRaw("getMarketByTerritory @TerritoryCode",
                new SqlParameter("@TerritoryCode", TerritoryCode)).ToListAsync();
        }

        public async Task<Market> getMarketbyCode(string marketCode)
        {
            return await new GenericRepository<Market>(this.context).FindOne(M => M.MarketCode == marketCode && M.IsActive == true);
        }


        public async Task<Market> updateMarket(string marketCode, Market Entity)
        {
            //Entity.UpdatedOn = DateTime.Now;
            return await new GenericRepository<Market>(this.context).Update(Entity, M => M.MarketCode == marketCode);
        }
        public async Task<List<ChemistInvoiceAllowedDuration>> insertPendingPartycodeToTransfer(List<ChemistInvoiceAllowedDuration> Entity)
        {
            return await new GenericRepository<ChemistInvoiceAllowedDuration>(this.context).InsertBulk(Entity);
        }

        public async Task<List<TerritoryChemistSalesReportDto>> getTerritoryChemistSalesReport(string TerritoryCode, string FromDate, string ToDate)
        {
            var data = await this.context.Set<TerritoryChemistSalesReportDto>().FromSqlRaw("getTerritoryChemistSalesReport @TerritoryCode, @FromDate, @ToDate",
                new SqlParameter("@TerritoryCode", TerritoryCode), new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        public async Task<List<ChemistInfoDto>> getChemistInfo(string ChemistCode)
        {
            var data = await this.context.Set<ChemistInfoDto>().FromSqlRaw("getChemistInfo @ChemistCode",
                new SqlParameter("@ChemistCode", ChemistCode)).ToListAsync();
            return data;
        }



        //END Of Author Shamsul Hasan Siam

        //public async Task<int> getChemistNumber()
        //{
        //    var result =  await new GenericRepository<Chemist>(this.context).GetAll();
        //    return result.Max(i => i.);
        //}

        //public async Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string LocationCode, string DateFrom, string DateTo, string InvoiceList, InvoicePaymentStatusParameters filter)
        //{
        //    var data = await this.context.Set<InvoicePaymentStatusDto>().FromSqlRaw("getInvoicePaymentStatus @SearchText, @LocationCode, @DateFrom, @DateTo, @InvoiceList ",
        //        new SqlParameter(parameterName: "@SearchText", SearchText), 
        //        new SqlParameter(parameterName: "@LocationCode", LocationCode), 
        //        new SqlParameter("@DateFrom", DateFrom),
        //        new SqlParameter("@DateTo", DateTo),
        //        new SqlParameter("@InvoiceList", InvoiceList)
        //        )
        //        .ToListAsync();

        //    return data;
        //}

        public async Task<List<InvoicePaymentStatusDto>> getInvoicePaymentStatus(string SearchText, string LocationCode, string DateFrom, string DateTo, string InvoiceList, int PageNumber, string PageSize)
        {
            var data = await this.context.Set<InvoicePaymentStatusDto>().FromSqlRaw("getInvoicePaymentStatus @SearchText, @LocationCode, @DateFrom, @DateTo, @InvoiceList,@PageNumber, @PageSize ",
                new SqlParameter(parameterName: "@SearchText", SearchText),
                new SqlParameter(parameterName: "@LocationCode", LocationCode),
                new SqlParameter("@DateFrom", DateFrom),
                new SqlParameter("@DateTo", DateTo),
                new SqlParameter("@InvoiceList", InvoiceList),
                new SqlParameter("@PageNumber", PageNumber),
                new SqlParameter("@PageSize", PageSize)
                )
                .ToListAsync();

            return data;
        }



        public async Task<List<InvoiceCollectionStatusDTO>> getInvoiceCollectionStatus(string InvoiceCode)
        {
            var data = await this.context.Set<InvoiceCollectionStatusDTO>().FromSqlRaw("getInvoiceCollectionStatus @InvoiceCode",
                new SqlParameter(parameterName: "@InvoiceCode", InvoiceCode)).ToListAsync();
            return data;
        }




    }
}
