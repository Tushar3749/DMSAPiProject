
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



using DMS.Core.DTO.Outstanding;
using DMS.Core.DTO.SummaryReturn;
using DMS.Services.Interfaces;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {

        private readonly ISummaryService service = null;
        public SummaryController(ISummaryService service)
        {
            this.service = service;
        }



        // ================================================================================================================================
        // SUMMARY SAVE
        // ================================================================================================================================



        [HttpPost]
        [Route("~/api/summary/return/collection/save")]
        public async Task<ActionResult> saveSummaryReturnCollection([FromBody] SummaryReturnNewDto SummaryNewDto)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data. Model State is not valid for SummaryReturnNewDto"));

                var json = new JSONSerialize().getJSONString(SummaryNewDto);
                Scripting.writeFile(ref json, @"D:\WEB SERVER\Log\DMS\applog.ini");

                var res = await service.saveSummaryReturnCollection(SummaryNewDto, this.getSessionUser());
                return getResponse(res);
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpPost]
        [Route("~/api/summary/collection/save")]
        public async Task<ActionResult> saveSummaryCollection([FromBody] SummaryDueCollectionDto SummaryCollection)
        {
            try
            {
                var res = await service.saveSummaryCollection(SummaryCollection, this.getSessionUser());
                return getResponse(res);
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/allocation/invoice/for/summary/{allocationcode}")]
        public async Task<ActionResult> getAllocationInvoiceForSummary(string allocationcode)
        {
            try
            {
                return getResponse(await service.getAllocationInvoiceForSummary(allocationcode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/date/between/{fromdate}/{todate}/{paymentmode}/{status}")]
        public async Task<ActionResult> getSalesInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode,string Status)
        {
            try
            {
                return getResponse(await service.getSalesInvoiceDateBetween(FromDate, ToDate, PaymentMode,Status));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/sales/date/between/{fromdate}/{todate}/{paymentmode}")]
        public async Task<ActionResult> getSalesDateBetween(string FromDate, string ToDate, string Paymentmode)
        {
            try
            {
                return getResponse(await service.getSalesDateBetween(FromDate, ToDate,Paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        //[HttpGet]
        //[Route("~/api/get/depot/employee/by/employee/code/{DACode}")]
        //public async Task<ActionResult> getSalesEmployee(string DACode)
        //{
        //    try
        //    {
        //        return getResponse(await service.getSalesEmployee(DACode));
        //    }
        //    catch (Exception ex) { return getResponse(ex); }
        //}

        [HttpPost]
        [Route("~/api/summary/invoice/update/for/summary")]
        public async Task<ActionResult> updateSummaryInvoiceForNewSummary([FromBody] AllocationInvoiceForSummaryMasterDto SummaryInvoice)
        {
            try
            {
                return getResponse(await service.updateSummaryInvoiceForNewSummary(SummaryInvoice));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/invoice/return/type")]
        public async Task<ActionResult> getInvoiceReturnType()
        {
            try
            {
                return getResponse(await service.getInvoiceReturnType());
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/sales/invoice/by/territory/mpo/{fromdate}/{todate}/{code}/{paymentmode}")]
        public async Task<ActionResult> getSalesInvoiceByTerritoryORMpo(string FromDate, string ToDate, string Code, string Paymentmode)
        {
            try
            {
                return getResponse(await service.getSalesInvoiceByTerritoryORMpo(FromDate, ToDate, Code,Paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

        [HttpGet]
        [Route("~/api/sales/invoice/by/code/{code}")]
        public async Task<ActionResult> getSalesInvoiceByCode(string Code)
        {
            try
            {
                return getResponse(await service.getSalesInvoiceByCode(Code));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

        [HttpGet]
        [Route("~/api/sales/by/territory/{fromdate}/{todate}/{code}/{paymentmode}")]
        public async Task<ActionResult> getSalesByMPOTerritory(string FromDate, string ToDate, string Code, string Paymentmode)
        {
            try
            {
                return getResponse(await service.getSalesByMPOTerritory(FromDate, ToDate, Code, Paymentmode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/sales/by/code/{code}")]
        public async Task<ActionResult> getSalesByCode(string Code)
        {
            try
            {
                return getResponse(await service.getSalesByCode(Code));
            }
            catch (Exception ex) { return getResponse(ex); }

        }
        [HttpGet]
        [Route("~/api/sales/by/area/{fromdate}/{todate}/{areaid}/{paymentmode}")]
        public async Task<ActionResult> getSalesByArea(string FromDate, string ToDate, string AreaID,string PaymentMode)
        {
            try
            {
                return getResponse(await service.getSalesByArea(FromDate, ToDate, AreaID, PaymentMode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/depot/location/region")]
        public async Task<ActionResult> getRegionList()
        {
            try
            {
                return getResponse(await service.getRegionList());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/depot/location/area")]
        public async Task<ActionResult> getArea()
        {
            try
            {
                return getResponse(await service.getArea());
            }
            catch (Exception ex) { return getResponse(ex); }

        }
        [HttpGet]
        [Route("~/api/batch/wise/sales/and/return/{fromdate}/{todate}")]
        public async Task<ActionResult> getBatchWiseReturn(string FromDate, string ToDate)
        {
            try
            {
                return getResponse(await service.getBatchWiseReturn(FromDate, ToDate));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/product/wise/sales/and/return/{fromdate}/{todate}")]
        public async Task<ActionResult> getProductWiseReturn(string FromDate, string ToDate)
        {
            try
            {
                var result =  getResponse(await service.getProductWiseReturn(FromDate, ToDate));
                return result;
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/all/territory/regionwise/{regioncode}")]
        public async Task<ActionResult> getAllAreaCodeByRegion(string RegionCode)
        {
            try
            {
                return getResponse(await service.getAllAreaCodeByRegion(RegionCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/all/territory/areawise/{areacode}")]
        public async Task<ActionResult> getAllTerritoryCodeByRegion(string AreaCode)
        {
            try
            {
                return getResponse(await service.getAllTerritoryCodeByArea(AreaCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/product/wise/sales/{fromdate}/{todate}/{areacode}")]
        public async Task<ActionResult> getProductWiseSales(string FromDate, string ToDate,string AreaCode)
        {
            try
            {
                return getResponse(await service.getProductWiseSales(FromDate, ToDate, AreaCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpPost]
        [Route("~/api/invoice/sales/by/territory")]
        public async Task<ActionResult> getSalesByTerritory([FromBody] OutstandingDto outstandingDto)
        {
            try
            {
                byte[] data = Convert.FromBase64String(outstandingDto.Code);
                outstandingDto.Code = Encoding.UTF8.GetString(data);

                return getResponse(await service.getSalesByTerritory(outstandingDto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/unadjusted/credit/note/list")]
        public async Task<ActionResult> getUnadjustedCreditNoteList()
        {
                try
                {
                    return getResponse(await service.getUnadjustedCreditNoteList());
                }
                catch (Exception ex) { return getResponse(ex); }

        }

    }
}
