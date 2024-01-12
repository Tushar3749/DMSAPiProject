
/*
 *=============================================
 *Author: Shamsul Hasan Siam
 *Email: siam.it@labaidpharma.com
 *Created on: 7 june 2020
 *Updated on: 
 *Last updated on:
 *Description: <>
 *=============================================
*/
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.Orders.OrderReport;
using DMS.Core.DTO.SalesOrder;
using DMS.Core.DTO.SalesOrder.AppOrder;
using DMS.Core.DTO.User;
using DMS.Services.Interfaces;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class SalesOrderController : ControllerBase
    {

        private readonly ISalesOrderService service;



        public SalesOrderController(ISalesOrderService service)
        {
            this.service = service;
        }



        [HttpGet]
        [Route("~/api/orders/{id}")]

        public async Task<ActionResult> getSalesOrder(int id)
        {
            try
            {
                return getResponse(await service.getSalesOrder(id));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        /*
        *=============================================
        *Author: Md. Rahat Hossain
        *Email: rahat@labaidpharma.com
        *Created on: 09 June 2021=
        *=============================================
       */

        [HttpGet]
        [Route("~/api/sales/invoice/pending/orders")]
        public async Task<ActionResult> getOrdersForNewInvoice()
        {
            try
            {
                return getResponse(await service.getOrdersForNewInvoice());
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/pending/orders/product/stock/status")]
        public async Task<ActionResult> getOrderProductStockStatus()
        {
            try
            {
                return getResponse(await service.getOrderProductStockStatus());
            }
            catch (Exception ex) { return getResponse(ex); }

        }

        /*
        *=============================================
        * END Of Author Md. Rahat Hossian
        *=============================================
       */


        [Route("~/api/sales/order/save")]
        [HttpPost]
        public async Task<ActionResult> saveSalesOrder([FromBody] OrdersDto Order)
        {
            try
            {
                //var userID = User.Claims.Where(a => a.Type == "User").FirstOrDefault();

                //var loggedUser = this.getSessionUser();

                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(Order));

                return getResponse(await service.saveSalesOrder(Order, this.getSessionUser()));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

        // Author: Mehedi, 12 Jun,21
        [Route("~/api/sales/app/order/save")]
        [HttpPost]
        public async Task<ActionResult> saveSalesOrderFromApp([FromBody] AppOrderReceiveDto AppOrder)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(AppOrder));
                
                return getResponse(await service.saveSalesOrderFromApp(AppOrder, this.getSessionUser()));
            }
            catch (Exception ex) { return getResponse(ex); }

        }

        // Author: Mehedi, 12 Jun,21
        [Route("~/api/sales/app/order/print/done")]
        [HttpPost]
        public async Task<ActionResult> saveSalesOrderPrintDone([FromBody] List<SalesOrderReportDto> PrintOrders)
        {
            try
            {

                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                var _User = this.getSessionUser();
                await service.saveSalesOrderPrintDone(PrintOrders);

               return Ok("Done");
                
            }
            catch (Exception ex) { return getResponse(ex); }

        }


        [Route("~/api/territory/chemist/{territoryid}")]
        [HttpGet]
        public async Task<ActionResult> getTerritoryChemist(string territoryid)
        {
            try
            {
                return getResponse(await service.getTerritoryChemist(territoryid));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/MPO/by/territory/{territoryid}")]
        public async Task<ActionResult> getMPOByTerritory(string territoryid)
        {
            try
            {
                return getResponse(await service.getMPOByTerritory(territoryid));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/sales/order/report/{datefrom}/{dateto}/{searchtext}")]
        public async Task<ActionResult> getSalesOrderReport(string datefrom, string dateto, string searchtext)
        {
            try
            {
                return getResponse(await service.getSalesOrderReport(datefrom, dateto, searchtext));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/sales/order/report/detail/{ordercode}")]
        public async Task<ActionResult> getSalesOrderReportDetail(string ordercode)
        {
            try
            {
                return getResponse(await service.getSalesOrderReportDetail(ordercode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/sales/order/report/{datefrom}/{dateto}")]
        public async Task<ActionResult> getSalesOrderReportForPrint(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getSalesOrderReportForPrint(datefrom, dateto,"0"));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/receive/order/report/{datefrom}/{dateto}")]
        public async Task<ActionResult> getReceiveOrderReportForPrint(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getSalesOrderReportForPrint(datefrom, dateto, "RECEIVED_ORDERS"));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        //[HttpGet]
        //[Route("~/api/sales/order/report/{datefrom}/{dateto}/{searchtext}")]
        //public async Task<ActionResult> getSalesOrderReportForPrint(string datefrom, string dateto, string searchtext)
        //{
        //    try
        //    {
        //        return getResponse(await service.getSalesOrderReportForPrint(datefrom, dateto, searchtext));
        //    }
        //    catch (Exception ex)
        //    {
        //        return getResponse(ex);
        //    }
        //}

        [HttpGet]
        [Route("~/api/received/order/{datefrom}/{dateto}")]
        public async Task<ActionResult> getReceivedOrder(string datefrom, string dateto)
        {

            try
            {
                return getResponse(await service.getReceivedOrder(datefrom, dateto));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [Route("~/api/sales/order/cancel")]
        [HttpPost]
        public async Task<ActionResult> cancelOrder([FromBody] CancelledOrderDto AppOrder)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(AppOrder));

                return getResponse(await service.cancelOrder(AppOrder, this.getSessionUser()));
            }
            catch (Exception ex) { return getResponse(ex); }

        }


    }



}
