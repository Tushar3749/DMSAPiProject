using DMS.Core.DTO.Chemist;
using DMS.Core.Models.SalesInvoice;
using DMS.Services.Interfaces;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Controllers
{
 //   [Authorize]
 
    [ApiController]
    public class ChemistController : ControllerBase
    {
        private readonly IChemistService service;

        public ChemistController(IChemistService service)
        {
            this.service = service;

        }

        [Route("~/api/labaid/employee/chemist/{ChemistID}")]
        [HttpGet]
        public async Task<ActionResult> getLabaidEmployeeChemist(string ChemistID)
        {
            try
            {
                return getResponse(await service.getLabaidEmployeeChemist(ChemistID));
            }
            catch (Exception ex){ return getResponse(ex); }
        }

        [Route("~/api/chemist/profile/{ChemistID}")]
        [HttpGet]
        public async Task<ActionResult> getProducts(string ChemistID)
        {
            try
            {
                return getResponse(await service.getChemistProfile(ChemistID));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [Route("~/api/chemist/detail/{ChemistID}")]
        [HttpGet]
        public async Task<ActionResult> getChemistDetail(string ChemistID)
        {
            try
            {
                return getResponse(await service.getChemistDetail(ChemistID));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        //Added By Siam
        //Added on 10 JULY 2021

        [HttpGet]
        [Route("~/api/chemist/due/invoice/for/summary/{chemistcode}")]
        public async Task<ActionResult> getChemistDueInvoiceForSummary(string ChemistCode)
        {

            try
            {
                return getResponse(await service.getChemistDueInvoiceForSummary(ChemistCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/summary/due/invoice/for/summary/{summarycode}")]
        public async Task<ActionResult> getSummaryDueInvoiceForSummary(string SummaryCode)
        {

            try
            {
                return getResponse(await service.getSummaryDueInvoiceForSummary(SummaryCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/all/mpo/due")]
        public async Task<ActionResult> getAllMPODue()
        {

            try
            {
                return getResponse(await service.getAllMPODue());
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/mpo/due/invoice/for/summary/{mpocode}")]
        public async Task<ActionResult> getMPODueInvoiceForSummary(string MPOCode)
        {

            try
            {
                return getResponse(await service.getMPODueInvoiceForSummary(MPOCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        [HttpGet]
        [Route("~/api/chemist/business/date/wise/{fromdate}/{todate}/{chemistcode}")]
        public async Task<ActionResult> getChemistBusinessDateWise(string fromdate, string todate, string chemistcode)
        {
            try
            {
                return getResponse(await service.getChemistBusinessDateWise(fromdate, todate, chemistcode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/chemist/credit/status/{chemistcode}")]
        public async Task<ActionResult> getChemistCreditStatus(string chemistcode)
        {
            try
            {
                return getResponse(await service.getChemistCreditStatus(chemistcode));

            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/get/chemist/types")]
        public async Task<ActionResult> getChemistTypes()
        {
            try
            {
                return getResponse(await service.getChemistTypes());

            }
            catch (Exception ex) { return getResponse(ex); }
        }



        [HttpGet]
        [Route("~/api/chemist/by/search/{locationcode}/{chemisttypecode}/{searchtext}")]
        public async Task<ActionResult> getChemistBySearch(string LocationCode, string ChemistTypeCode, string SearchText)
        {
            try
            {
                return getResponse(await service.getChemistBySearch(LocationCode, ChemistTypeCode, SearchText));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/market/by/territory/{TerritoryCode}")]
        public async Task<ActionResult> getMarketByTerritory(string TerritoryCode)
        {
            try
            {
                return getResponse(await service.getMarketByTerritory(TerritoryCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/territory/chemist/sales/{territorycode}/{datefrom}/{dateto}")]
        public async Task<ActionResult> getTerritoryChemistSalesReport(string territorycode, string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getTerritoryChemistSalesReport(territorycode, datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        //get chemist info
        [HttpGet]
        [Route("~/api/chemist/info/{ChemistCode}")]
        public async Task<ActionResult> getChemistInfo(string ChemistCode)
        {
            try
            {
                return getResponse(await service.getChemistInfo(ChemistCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }



        //Update or deactivate Market
        //[HttpPost]
        //[Route("~/api/market/update")]
        //public async Task<ActionResult> updateMarket(MarketDto marketDto)
        //{
        //    try
        //    {
        //        return getResponse(await service.updateMarket(marketDto));
        //    }
        //    catch (Exception ex) { return getResponse(ex); }

        //}

        //[HttpPost]
        //[Route("~/api/new/chemist/save/{chemistData}/{creditData}/{territoryData}")]
        //public async Task<ActionResult> saveChemist([FromBody] ChemistDto chemistData, [FromBody] ChemistCreditDto creditData, [FromBody] ChemistTerritoryDto territoryData)
        //{
        //    try
        //    {
        //        return getResponse(await service.saveChemist(chemistData, creditData, territoryData));
        //    }
        //    catch (Exception ex) { return getResponse(ex); }

        //}
        //END Of Author Shamsul Hasan Siam

 
        [HttpGet]
        [Route("~/api/invoice/payment/status/{searchText}/{locationCode}/{datefrom}/{dateto}/{invoiceList}/{pagenumber}/{pagesize}")]
        public async Task<ActionResult> getInvoicePaymentStatus(string searchText, string locationCode, string datefrom, string dateto, string invoiceList,int pagenumber,string pagesize)
        {
            try
            {                
                return getResponse(await service.getInvoicePaymentStatus(searchText,locationCode, datefrom, dateto, invoiceList,pagenumber,pagesize));
            }
            catch (Exception ex) { return getResponse(ex); }

            
        }

        [HttpGet]
        [Route("~/api/invoice/collection/status/{invoicecode}")]
        public async Task<ActionResult> getInvoiceCollectionStatus(string invoicecode)
        {
            try
            {
                return getResponse(await service.getInvoiceCollectionStatus(invoicecode));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

    }
}
