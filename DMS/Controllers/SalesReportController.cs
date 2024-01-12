/*
*=============================================
*Author: MEHEDI
*Email: mehedi@labaidpharma.com
*Created on:  24 OCT 2021
*Updated on: 
*Last updated on:
*Description: <>
*=============================================
*/



using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SalesReportController : ControllerBase
    {


        private readonly ISalesReportService service = null;
        public SalesReportController(ISalesReportService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/location/wise/sales/report/{locationcode}/{datefrom}/{dateto}/{paymentmode}")]
        public async Task<ActionResult> getLocationWiseSalesReport(string locationcode, string datefrom, string dateto, string paymentmode)
        {
            try
            {
                return getResponse(await service.getLocationWiseSalesReport(locationcode, datefrom, dateto, paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/product/wise/sales/report/{locationcode}/{datefrom}/{dateto}/{paymentmode}")]
        public async Task<ActionResult> getProductSalesSummaryReport(string locationcode, string datefrom, string dateto, string paymentmode)
        {
            try
            {
                return getResponse(await service.getProductSalesSummaryReport(locationcode, datefrom, dateto, paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/location/wise/product/return/{locationcode}/{datefrom}/{dateto}/{paymentmode}")]
        public async Task<ActionResult> getLocationWiseProductReturn(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            try
            {
                return getResponse(await service.getLocationWiseProductReturn(LocationCode, DateFrom, DateTo, PaymentMode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/order/status/report/{datefrom}/{dateto}/{searchtext}")]
        public async Task<ActionResult> getOrderStatusReport(string datefrom, string dateto, string searchtext)
        {
            try
            {
                return getResponse(await service.getOrderStatusReport(datefrom, dateto, searchtext));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/sales/location/list/{parentlocationcode}/{locationlevel}")]
        public async Task<ActionResult> getLocationSales(string parentlocationcode, string locationlevel)
        {
            try
            {
                return getResponse(await service.getLocationSales(parentlocationcode, locationlevel));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/sales/and/collection/for/dashboard/{FromDate}/{ToDate}")]
        public async Task<ActionResult> getSalesAndCollectionForDashboard(string FromDate, string ToDate)
        {

            try
            {
                return getResponse(await service.getSalesAndCollectionForDashboard(FromDate, ToDate));
            }
            catch (Exception ex) { return getResponse(ex); }
        }



        [HttpGet]
        [Route("~/api/product/wise/location/sales/{locationcode}/{locationlevel}/{datefrom}/{dateto}/{paymentmode}")]
        public async Task<ActionResult> getProductWiseLocationSalesReport(string locationcode, string locationlevel, string datefrom, string dateto, string paymentmode)
        {
            try
            {
                return getResponse(await service.getProductWiseLocationSalesReport(locationcode, locationlevel, datefrom, dateto, paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/depot/field/force/{regioncode}")]
        public async Task<ActionResult> getDepotFieldForce(string RegionCode)
        {
            try
            {
                return getResponse(await service.getDepotFieldForce(RegionCode));
            }
            catch (Exception ex) { return getResponse(ex); }


        }

        [HttpGet]
        [Route("~/api/depot/field/force/excel/{regioncode}")]
        public async Task<ActionResult> getDepotFieldForceForExel(string RegionCode)
        {
            try
            {
                return getResponse(await service.getDepotFieldForceForExcel(RegionCode));
            }
            catch (Exception ex) { return getResponse(ex); }


        }


        [HttpGet]
        [Route("~/api/location/wise/sales/report/excel/{locationcode}/{datefrom}/{dateto}/{paymentmode}")]
        public async Task<ActionResult> getLocationWiseSalesReportForExcel(string locationcode, string datefrom, string dateto, string paymentmode)
        {
            try
            {
                return getResponse(await service.getLocationWiseSalesReportForExcel(locationcode, datefrom, dateto, paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        // Name: Somaiya Jannat, somaiyajannat044@gmail.com
        // Date: 17 june 2023
        // Description: location wise chemist sales, collection, due

        [HttpGet]
        [Route("~/api/chemist/wise/sales/report/{locationcode}/{datefrom}/{dateto}")]

        public async Task<ActionResult> getChemistWiseSalesReport(string locationcode, string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getChemistWiseSalesReport(locationcode, datefrom, dateto));
                
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
            

          
        }
    }
}
