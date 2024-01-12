using DMS.Core.DTO.BonusAndDiscount;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.DayOperation;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.Report.Outstanding;
using DMS.Core.DTO.SalesMaster;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public abstract class SalesReportContext_SPModels : DbContext
    {
        
        public SalesReportContext_SPModels() : base()
        {
            
        }

        



        /*
        *=============================================
        * END Of Author Shafiqul Bari Sadman
        *=============================================
        */ 
        
        
        /*
       *=============================================
       *Author: MEHEDI
       *Email: mehedi@labaidpharma.com
       *Created on: 19 JUNE 2021
       *Updated on: 
       *Last updated on:
       *Description: <>
       *=============================================
        */

        protected virtual DbSet<LocationWiseSalesReportDto> LocationWiseSalesReportDto { get; set; }
        protected virtual DbSet<ProductSalesSummaryReportDto> ProductSalesSummaryReportDto { get; set; }
        protected virtual DbSet<OrderStatusReportDto> OrderStatusReportDto { get; set; }
        protected virtual DbSet<LocationRegionDto> LocationRegionDto { get; set; }
        protected virtual DbSet<LocationAreaDto> LocationAreaDto { get; set; }
        protected virtual DbSet<LocationTerritoryDto> LocationTerritoryDto { get; set; }

        protected virtual DbSet<LocationSalesDto> LocationSalesDto { get; set; }
        protected virtual DbSet<SalesAndCollectionForDashboardDto> SalesAndCollectionForDashboardDto { get; set; }

        protected virtual DbSet<Location> Location { get; set; }
        protected virtual DbSet<ProductWiseLocationSalesDto> ProductWiseLocationSalesDto { get; set; }
        protected virtual DbSet<FieldForceDto> FieldForceDto { get; set; }
        protected virtual DbSet<LocationWiseProductReturnDto> LocationWiseProductReturnDto { get; set; }
        protected virtual DbSet<ChemistWiseSalesReportDto> ChemistWiseSalesReportDto { get; set; }





        /*
        *=============================================
        * END Of Author
        *=============================================
        */


    }
}
