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


using DMS.Core.DTO;
using DMS.Core.DTO.Chemist;
using DMS.Core.DTO.Locations;
using DMS.Core.DTO.Report;
using DMS.Core.DTO.SalesMaster;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.Models.Report;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Formulas;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.Report
{
    public class SalesReportService : ISalesReportService
    {
        private Exception Error;

        private readonly DbContext context;
        private readonly DbContext InvoiceContext;
        private readonly SalesReportRepository repo = null;
        private readonly ProductRepository pRepo = null;
        private readonly LocationRepository lRepo = null;

        public SalesReportService(IConfiguration Config)
        {
            this.context = new SalesReportContext(Config);
            this.InvoiceContext = new InvoiceContext(Config);

            this.repo = new SalesReportRepository(this.context);
            this.pRepo = new ProductRepository(this.InvoiceContext);
            this.lRepo = new LocationRepository(this.InvoiceContext);
        }

        public async Task<List<LocationWiseProductSalesReport>> getLocationWiseSalesReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {

            List<LocationWiseProductSalesReport> report = new List<LocationWiseProductSalesReport>();

            SalesInvoiceFormula formula = new SalesInvoiceFormula();

            var data = await repo.getLocationWiseSalesReport(LocationCode, DateFrom, DateTo, PaymentMode);

            var areas = data.GroupBy(l => l.AreaID).Select(l=> l.First()).ToList();

            foreach (var area in areas)
            {
                LocationWiseProductSalesReport rpt = new LocationWiseProductSalesReport();

                rpt.RegionID = area.RegionID;
                rpt.RegionName = area.RegionName;
                rpt.RegionalManagerID = area.RegionalManagerID;
                rpt.RegionalManagerName = area.RegionalManagerName;

                rpt.AreaID = area.AreaID;
                rpt.AreaName = area.AreaName;
                rpt.AreaManagerID = area.AreaManagerID;
                rpt.AreaManagerName = area.AreaManagerName;



                // Territory Detail
                var territories = data.Where(l => l.AreaID == area.AreaID).Select(t => new LocationWiseSalesTerritoryDetails { 
                    TerritoryID = t.TerritoryID,
                    TerritoryName = t.TerritoryName,
                    MPOID = t.MPOID,
                    MPOName = t.MPOName,

                    TransitInvoiceNumber = t.TransitInvoiceNumber,
                    TransitTP = t.TransitTP,
                    TransitProductDiscount = t.TransitProductDiscount,  
                    TransitVAT = t.TransitVAT,
                    TransitTradeDiscount = t.TransitTradeDiscount,  
                    
                    SoldInvoiceNumber = t.SoldInvoiceNumber,
                    SoldTP = t.SoldTP,
                    SoldVAT = t.SoldVAT,
                    SoldTradeDiscount = t.SoldTradeDiscount,
                    SoldProductDiscount = t.SoldProductDiscount,
                    ReturnValue = t.ReturnValue,
                });


                if (territories.Any())
                {
                    rpt.TerritoryDetail = new List<LocationWiseSalesTerritoryDetails>();

                    if (territories.Any())
                    {
                        rpt.TerritoryDetail.AddRange(territories);

                        foreach (var territory in rpt.TerritoryDetail)
                        {
                            territory.TotalTP = territory.TransitTP.GetValueOrDefault() + territory.SoldTP.GetValueOrDefault();
                            territory.TotalVAT = territory.TransitVAT.GetValueOrDefault() + territory.SoldVAT.GetValueOrDefault();
                            territory.TotalProductDiscount = territory.TransitProductDiscount.GetValueOrDefault() + territory.SoldProductDiscount.GetValueOrDefault();
                            territory.TotalTradeDiscount = territory.TransitTradeDiscount.GetValueOrDefault() + territory.SoldTradeDiscount.GetValueOrDefault();


                            territory.TransitAmount = formula.getNetAmount(territory.TransitTP.GetValueOrDefault(), territory.TransitVAT.GetValueOrDefault(), territory.TransitProductDiscount.GetValueOrDefault(), territory.TransitTradeDiscount.GetValueOrDefault());
                            territory.SoldAmount = formula.getNetAmount(territory.SoldTP.GetValueOrDefault(), territory.SoldVAT.GetValueOrDefault(), territory.SoldProductDiscount.GetValueOrDefault(), territory.SoldTradeDiscount.GetValueOrDefault());

                            territory.TotalAmount = territory.TransitAmount.GetValueOrDefault() + territory.SoldAmount.GetValueOrDefault();
                        }
                    }

                    


                    // TRANSIT

                    rpt.TransitTP = rpt.TerritoryDetail.Sum(t=>t.TransitTP).Value;
                    rpt.TransitVAT = rpt.TerritoryDetail.Sum(t=>t.TransitVAT).Value;
                    rpt.TransitProductDiscount = rpt.TerritoryDetail.Sum(t=>t.TransitProductDiscount).Value;
                    rpt.TransitTradeDiscount = rpt.TerritoryDetail.Sum(t=>t.TransitTradeDiscount).Value;
                    
                   // SOLD

                    rpt.SoldTP = rpt.TerritoryDetail.Sum(t=>t.SoldTP).Value;
                    rpt.SoldVAT = rpt.TerritoryDetail.Sum(t=>t.SoldVAT).Value;
                    rpt.SoldProductDiscount = rpt.TerritoryDetail.Sum(t=>t.SoldProductDiscount).Value;
                    rpt.SoldTradeDiscount = rpt.TerritoryDetail.Sum(t=>t.SoldTradeDiscount).Value;


                    // TOTAL

                    rpt.TotalTP = rpt.TerritoryDetail.Sum(t => t.TotalTP).Value;
                    rpt.TotalVAT = rpt.TerritoryDetail.Sum(t => t.TotalVAT).Value;
                    rpt.TotalProductDiscount = rpt.TerritoryDetail.Sum(t => t.TotalProductDiscount).Value;
                    rpt.TotalTradeDiscount = rpt.TerritoryDetail.Sum(t => t.TotalTradeDiscount).Value;

                    rpt.TransitAmount = rpt.TerritoryDetail.Sum(t => t.TransitAmount).Value;
                    rpt.SoldAmount = rpt.TerritoryDetail.Sum(t => t.SoldAmount).Value;
                    rpt.TotalAmount = rpt.TerritoryDetail.Sum(t => t.TotalAmount).Value;

                    rpt.ReturnValue = rpt.TerritoryDetail.Sum(t => t.ReturnValue).Value;

                    //rpt.TransitTP = territories.Sum(t=>t.TransitTP).GetValueOrDefault();
                }

                report.Add(rpt);
            }


            return report;
        }


        public async Task<List<ProductSalesSummaryReportDto>> getProductSalesSummaryReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
	        
		    return await repo.getProductSalesSummaryReport(LocationCode, DateFrom, DateTo, PaymentMode);	        
	       
        }


        public async Task<List<OrderStatusReportDto>> getOrderStatusReport(string DateFrom, string DateTo, string SearchText)
        {
            
            return await repo.getOrderStatusReport(DateFrom, DateTo, SearchText);
            
        }



        public async Task<object> getLocationSales(string ParentLocationCode, string LocationLevel)
        {
           
            if(LocationLevel=="RM") return await repo.getLocationRegion();
            if(LocationLevel=="AM") return await repo.getLocationArea(ParentLocationCode, LocationLevel);
            if(LocationLevel=="TM") return await repo.getLocationTerritory(ParentLocationCode, LocationLevel);
            else return await repo.getLocationSales(ParentLocationCode, LocationLevel);
           
        }

        public async Task<List<SalesAndCollectionForDashboardDto>> getSalesAndCollectionForDashboard(string FromDate, string ToDate)
        {
             return await repo.getSalesAndCollectionForDashboard(FromDate, ToDate);
        }


        public async Task<object> getProductWiseLocationSalesReport(string LocationCode, string LocationLevel, string DateFrom, string DateTo, string PaymentMode)
        {
            List<ProductWiseLocationSalesReport> report = new List<ProductWiseLocationSalesReport>();
            List<ProductsDto> products = await pRepo.getProducts();

            var productSales = await repo.getProductWiseLocationSalesReport(LocationCode, DateFrom, DateTo, PaymentMode);
            List<TerritoryDTO> locations = await lRepo.GetAllTerritory(LocationCode);
            locations = locations.OrderBy(l=> l.TerritoryCode).ToList();

            List<LocationAreaDto> areas = null;
            

            List<LocationDto> Locations = new List<LocationDto>();
            if (LocationLevel == "AM")
            {
                areas = await repo.getLocationArea(LocationCode, LocationLevel);
                foreach (var item in areas) Locations.Add(new LocationDto { LocationCode = item.AreaID, LocationName = item.AreaName });
            }
            else foreach (var item in locations) Locations.Add(new LocationDto { LocationCode = item.TerritoryCode, LocationName = item.TerritoryName });




            foreach (var product in products)
            {
                ProductWiseLocationSalesReport rpt = new ProductWiseLocationSalesReport();

                rpt.ProductCode = product.ProductCode; 
                rpt.ProductName = product.ProductName;
                rpt.PackSize = product.PackSize;
                rpt.TP = product.TP;

                rpt.LocationSales = new List<ProductWiseLocationSalesDto>();



                if (LocationLevel == "AM")
                {
                    foreach (var location in areas)
                    {
                        var locationSales = productSales.Where(p => p.ProductCode == product.ProductCode && p.LocationCode == location.AreaID).FirstOrDefault();
                        if (locationSales != null) rpt.LocationSales.Add(locationSales);
                        else rpt.LocationSales.Add(new ProductWiseLocationSalesDto { LocationCode = location.AreaID, SoldQuantity = null, TotalTP = null }) ;
                    }

                }
                else
                {
                    foreach (var location in locations)
                    {
                        var locationSales = productSales.Where(p => p.ProductCode == product.ProductCode && p.LocationCode == location.TerritoryCode).FirstOrDefault();
                        if (locationSales != null) rpt.LocationSales.Add(locationSales);
                        else rpt.LocationSales.Add(new ProductWiseLocationSalesDto { LocationCode = location.TerritoryCode, SoldQuantity = null, TotalTP = null });
                    }
                }


                rpt.ProductSoldQuantity = rpt.LocationSales.Sum(t=> t.SoldQuantity).Value;
                rpt.ProductTotalTP = rpt.LocationSales.Sum(t=> t.TotalTP).Value;
                report.Add(rpt);
            }

            report = report.Where(t=> t.ProductSoldQuantity>0).ToList();
            
            return new { Location = Locations, Report = report };
        }
        public async Task<List<LocationWiseProductReturnDto>> getLocationWiseProductReturn(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {    
                return await repo.getLocationWiseProductReturn(LocationCode, DateFrom, DateTo, PaymentMode);
        }


        public async Task<List<RMDetails>> getDepotFieldForce(string RegionCode)
        {

            try
            {
               
                var data = await repo.getDepotFieldForce(RegionCode);
                var regions = data.GroupBy(g => g.RegionCode).Select(s => s.First()).OrderBy(o=>o.RegionCode).ToList();


                //List<FieldForceDtoCustom> rpt = new List<FieldForceDtoCustom>();

                List<RMDetails> RMList = new List<RMDetails>();

                foreach (var region in regions)
                {

                    RMDetails rm = new RMDetails();

                    rm.RegionCode = region.RegionCode;
                    rm.REGIONNAME = region.REGIONNAME;
                    rm.RegionalManagerID = region.RegionalManagerID;
                    rm.RegionalManagerName = region.RegionalManagerName;
                    rm.RegionManagerMobileNumber = region.RegionManagerMobileNumber;
                    rm.RMTargetShare = region.RMTargetShare;



                    var areas = data.Select(s => new { s.RegionCode, s.AreaCode, s.AreaManagerID, s.AreaManagerMobileNumber, s.AreaManagerName, s.AREANAME, s.AMTargetShare }).Where(w => w.RegionCode == region.RegionCode).Distinct().OrderBy(o=>o.AreaCode).ToList();
                    List<AMDetails> AMList = new List<AMDetails>();


                    foreach (var area in areas)
                    {
                        AMDetails am = new AMDetails();

                        am.AreaCode = area.AreaCode;
                        am.AREANAME = area.AREANAME;
                        am.AreaManagerID = area.AreaManagerID;
                        am.AreaManagerName = area.AreaManagerName;
                        am.AreaManagerMobileNumber = area.AreaManagerMobileNumber == null?"8801xxxxxxxxx":area.AreaManagerMobileNumber ;
                        am.AMTargetShare = area.AMTargetShare;


                        var territories = data.Where(w => w.AreaCode == am.AreaCode).OrderBy(o=>o.TerritoryCode).ToList();

                        List<MPODetails> MPOList = new List<MPODetails>();

                        foreach (var territory in territories)
                        {
                            MPODetails mpo = new MPODetails();

                            mpo.AreaCode = territory.AreaCode;
                            mpo.TerritoryCode = territory.TerritoryCode;
                            mpo.TERRITORYNAME = territory.TERRITORYNAME;
                            mpo.MPOID = territory.MPOID;
                            mpo.MPOName = territory.MPOName;
                            mpo.MPOPhoneNumber = territory.MPOPhoneNumber==null?"8801xxxxxxxxx":territory.MPOPhoneNumber;
                            mpo.MPOTargetShare = territory.MPOTargetShare;

                            MPOList.Add(mpo);
                        }

                        am.MPOs =MPOList;
                        AMList.Add(am);
                    }

                    rm.AMs =AMList;
                    RMList.Add(rm);


                }

                // rpt.RMs = RMList;

                return RMList;
            }
            catch (Exception ex )
            {
                var err = ex;
                throw;
            }

        }


        public async Task<List<FieldForceDto>> getDepotFieldForceForExcel(string regionCode)
        {
            List<FieldForceDto> data = await repo.getDepotFieldForce(regionCode);
            return data;
        }

        public async Task<List<LocationWiseSalesReportDto>> getLocationWiseSalesReportForExcel(string locationcode, string datefrom, string dateto, string paymentmode)
        {
            List<LocationWiseSalesReportDto> data = await repo.getLocationWiseSalesReport(locationcode, datefrom, dateto,paymentmode);
            return data;
        }

        // Name: Somaiya Jannat, somaiyajannat044@gmail.com
        // Date: 17 june 2023
        // Description: location wise chemist sales, collection, due
        public async Task<List<ChemistWiseSalesReportDto>> getChemistWiseSalesReport(string locationcode, string datefrom, string dateto)
        {
            return await repo.getChemistWiseSalesReport(locationcode, datefrom, dateto);
        }
    }
}
