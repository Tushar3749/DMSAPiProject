/*
*=============================================
*Author: MEHEDI
*Email: mehedi@labaidpharma.com
*Created on: 24 OCT 2021
*Updated on: 
*Last updated on:
*Description: <>
*=============================================
*/



using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.SalesMaster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class SalesReportRepository : Repository
    {

        private DbContext context = null;
        public SalesReportRepository(DbContext context) : base(context)
        {
            this.context = context;            
        }


        public async Task<List<LocationWiseSalesReportDto>> getLocationWiseSalesReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            this.context.Database.SetCommandTimeout(600);
            var data = await this.context.Set<LocationWiseSalesReportDto>().FromSqlRaw("getLocationWiseSalesReport @LocationCode, @DateFrom, @DateTo, @PaymentMode",
                new SqlParameter("@LocationCode", LocationCode), 
                new SqlParameter("@DateFrom", DateFrom), 
                new SqlParameter("@DateTo", DateTo),
                new SqlParameter("@PaymentMode", PaymentMode)
                ).ToListAsync();
            return data;
        }

        
        public async Task<List<ProductSalesSummaryReportDto>> getProductSalesSummaryReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            var data = await this.context.Set<ProductSalesSummaryReportDto>().FromSqlRaw("getProductSalesSummaryReport @LocationCode, @DateFrom, @DateTo, @PaymentMode",
                new SqlParameter("@LocationCode", LocationCode), 
                new SqlParameter("@DateFrom", DateFrom), 
                new SqlParameter("@DateTo", DateTo),
                new SqlParameter("@PaymentMode", PaymentMode)
                ).ToListAsync();
            return data;
        }

        public async Task<List<LocationWiseProductReturnDto>> getLocationWiseProductReturn(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            var data = await this.context.Set<LocationWiseProductReturnDto>().FromSqlRaw("getLocationWiseProductReturn @LocationCode, @DateFrom, @DateTo, @PaymentMode",
                new SqlParameter("@LocationCode", LocationCode), new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
            return data;
        }

        public async Task<List<SalesAndCollectionForDashboardDto>> getSalesAndCollectionForDashboard(string FromDate, string ToDate)
        {
            var data = await this.context.Set<SalesAndCollectionForDashboardDto>().FromSqlRaw("getSalesAndCollectionForDashboard @FromDate, @ToDate",
                new SqlParameter("@FromDate", FromDate), new SqlParameter("@ToDate", ToDate)).ToListAsync();
            return data;
        }

        public async Task<List<OrderStatusReportDto>> getOrderStatusReport(string DateFrom, string DateTo, string SearchText)
        {
            if (string.IsNullOrEmpty(SearchText)) SearchText = "0";
            var data = await this.context.Set<OrderStatusReportDto>().FromSqlRaw("getOrderStatusReport @DateFrom, @DateTo, @SearchText",
                new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo), new SqlParameter("@SearchText", SearchText)).ToListAsync();
            return data;
        }

        public async Task<List<LocationRegionDto>> getLocationRegion()
        {
            var data = await this.context.Set<LocationRegionDto>().FromSqlRaw("getLocationSales '0', 'RM'").ToListAsync();
            return data;
        }

        

        public async Task<List<LocationAreaDto>> getLocationArea(string ParentLocationCode, string LocationLevel)
        {
            var data = await this.context.Set<LocationAreaDto>().FromSqlRaw("getLocationSales @ParentLocationCode, @LocationLevel",
                new SqlParameter("@ParentLocationCode", ParentLocationCode), new SqlParameter("@LocationLevel", LocationLevel)).ToListAsync();
            return data;
        }

        public async Task<List<LocationTerritoryDto>> getLocationTerritory(string ParentLocationCode, string LocationLevel)
        {
            var data = await this.context.Set<LocationTerritoryDto>().FromSqlRaw("getLocationSales @ParentLocationCode, @LocationLevel",
                new SqlParameter("@ParentLocationCode", ParentLocationCode), new SqlParameter("@LocationLevel", LocationLevel)).ToListAsync();
            return data;
        }

        public async Task<List<LocationSalesDto>> getLocationSales(string ParentLocationCode, string LocationLevel)
        {
            var data = await this.context.Set<LocationSalesDto>().FromSqlRaw("getLocationSales @ParentLocationCode, @LocationLevel",
                new SqlParameter("@ParentLocationCode", ParentLocationCode), new SqlParameter("@LocationLevel", LocationLevel)).ToListAsync();
            return data;
        }

        public async Task<List<ProductWiseLocationSalesDto>> getProductWiseLocationSalesReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            var data = await this.context.Set<ProductWiseLocationSalesDto>().FromSqlRaw("getProductWiseLocationSalesReport @LocationCode, @DateFrom, @DateTo, @PaymentMode",
                new SqlParameter("@LocationCode", LocationCode), new SqlParameter("@DateFrom", DateFrom), new SqlParameter("@DateTo", DateTo), new SqlParameter("@PaymentMode", PaymentMode)).ToListAsync();
            return data;
        }

        public async Task<List<FieldForceDto>> getDepotFieldForce(string RegionCode)
        {
            var data = await this.context.Set<FieldForceDto>().FromSqlRaw("getDepotFieldForce @RegionCode",
                new SqlParameter("@RegionCode", RegionCode)).ToListAsync();
            return data;
        }


        // Name: Somaiya Jannat, somaiyajannat044@gmail.com
        // Date: 17 june 2023
        // Description: location wise chemist sales, collection, due
        public async Task<List<ChemistWiseSalesReportDto>> getChemistWiseSalesReport(string locationcode, string datefrom, string dateto)
        {
            var data = await this.context.Set<ChemistWiseSalesReportDto>().FromSqlRaw("getChemistWiseSalesReport @locationcode, @datefrom, @dateto",
                new SqlParameter("@locationcode", locationcode),
                new SqlParameter("@datefrom", datefrom),
                new SqlParameter("@dateto", dateto)
                ).ToListAsync();
            return data;

        }


    }
}
