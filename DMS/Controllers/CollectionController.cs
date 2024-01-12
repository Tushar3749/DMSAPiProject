using DMS.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Services.Interfaces;
using DMS.Utility.Library;
using DMS.Core.DTO.User;

namespace DMS.Controllers
{

    /*
   *=============================================
   *Author: Rahat Hossain
   *Email: rahat@labaidpharma.com
   *Created on: 26 JUNE 2021
   *Updated on: 
   *Last updated on:
   *Description: <>
   *=============================================
  */
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService service;
      
        public CollectionController(ICollectionService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Route("~/api/summary/collection/money/receipt/pending")]
        // GET api/<controller>
        public async Task<ActionResult> getSumCollMoneyReceiptPending()
        {
            try
            {
                return getResponse(await service.getSumCollMoneyReceiptPending());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/summary/collection/date/between/{FromDate}/{ToDate}")]
        // GET api/<controller>
        public async Task<ActionResult> getSumCollDateBetween(string FromDate, string ToDate)
        {
            try
            {
                return getResponse(await service.getSumCollDateBetween(FromDate, ToDate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/summary/collection/money/receipt/detail/{CollectionCode}")]
        // GET api/<controller>
        public async Task<ActionResult> getSumCollMoneyReceiptDetail(string CollectionCode)
        {
            try
            {
                return getResponse(await service.getSumCollMoneyReceiptDetail(CollectionCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/summary/collection/by/code/{fromdate}/{todate}/{dacode}")]
        public async Task<ActionResult> getSummaryCollectionByDACode(string FromDate, string ToDate, string DACode)
        {

            try
            {
                return getResponse(await service.getSummaryCollectionByDACode(FromDate, ToDate, DACode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/summary/collection/by/code/{code}")]
        public async Task<ActionResult> getSummaryCollectionByCode(string Code)
        {
            try
            {
                return getResponse(await service.getSummaryCollectionByCode(Code));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
        [HttpGet]
        [Route("~/api/get/all/region")]
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
        [Route("~/api/summary/collection/date/between/region/{FromDate}/{ToDate}/{RegionCode}/{AreaCode}/{TerritoryCode}")]
        public async Task<ActionResult> getSumCollDateBetweenAndRegion(string FromDate, string ToDate,string RegionCode,string AreaCode,string TerritoryCode)
        {
            try
            {
                return getResponse(await service.getSumCollDateBetweenAndRegion(FromDate,ToDate,RegionCode, AreaCode, TerritoryCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
    }
}
