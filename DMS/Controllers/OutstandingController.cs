using DMS.Core.DTO.Outstanding;
using DMS.Services.Interfaces;
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
    public class OutstandingController : ControllerBase
    {
        //Added By Siam
        //Added on 11 JULY 2021
        private readonly IOutstandingService service = null;
        public OutstandingController(IOutstandingService service)
        {
            this.service = service;
        }

        

        //END Of Author Shamsul Hasan Siam

   


        [HttpGet]
        [Route("~/api/invoice/outstanding/locationwise/{locationcode}/{paymentmode}/{datefrom}/{dateto}")]
        public async Task<ActionResult> getInvoiceOutstandingLocationWise(string locationcode, string paymentmode, string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getInvoiceOutstandingLocationWise(locationcode, paymentmode, datefrom, dateto));
            }
            catch (Exception ex){return getResponse(ex);}
        }

        [HttpGet]
        [Route("~/api/location/wise/outstanding/for/excel/{locationcode}/{paymentmode}/{fromdate}/{dateto}")]
        public async Task<ActionResult> getInvoiceOutstandingLocationWiseForExcel(string LocationCode, string PaymentMode, string FromDate, string DateTo)
        {
            try
            {
                return getResponse(await service.getOutstandingLocationWiseForExcel(LocationCode, PaymentMode, FromDate, DateTo));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/outstanding/locationwise/detail/{locationcode}/{searchbycode}/{paymentmode}/{datefrom}/{dateto}")]
        public async Task<ActionResult> getOutstandingLocationWiseDetail(string locationcode, string searchbycode, string paymentmode, string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getOutstandingLocationWiseDetail(locationcode, searchbycode, paymentmode, datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/location/wise/outstanding/detail/for/excel/{locationcode}/{searchbycode}/{paymentmode}/{fromdate}/{dateto}")]
        public async Task<ActionResult> getOutstandingLocationWiseDetailForExcel(string LocationCode, string SearchByCode, string PaymentMode, string FromDate, string DateTo)
        {
            try
            {
                return getResponse(await service.getLocationWiseOutstandingDetailForExcel(LocationCode, SearchByCode, PaymentMode, FromDate, DateTo));
            }
            catch (Exception ex) { return getResponse(ex); }
        }



    }
}
