/*
*=============================================
*Author: Shamsul Hasan Siam
*Email: siam.it@labaidpharma.com
*Created on: 21 JUNE 2021
*Updated on: 
*Last updated on:
*Description: <>
*=============================================
*/

using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    public class DiscountController : ControllerBase
    {



        private readonly IDiscountService service;



        public DiscountController(IDiscountService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/discount/by/search/{LocationCode}/{ProductCode}/{SearchText}")]
        public async Task<ActionResult> getDiscountBySearch(string LocationCode, string ProductCode, string SearchText)
        {
            try
            {
                var result = getResponse(await service.getDiscountBySearch(LocationCode, ProductCode, SearchText));
                return result;
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/discount/report/{discountid}")]
        // GET api/<controller>
        public async Task<ActionResult> getDiscountReport(string discountid)
        {
            try
            {
                return getResponse(await service.getDiscountReport(new DMS.Utility.Library.JSONSerialize().DecodeBase64(discountid)));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/discount/detail/{discountid}")]
        // GET api/<controller>
        public async Task<ActionResult> getDiscountDetail(string discountid)
        {
            try
            {
                return getResponse(await service.getDiscountDetail(new DMS.Utility.Library.JSONSerialize().DecodeBase64(discountid)));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
    }
}
