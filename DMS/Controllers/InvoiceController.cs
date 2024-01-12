using DMS.Core.DTO.SalesInvoice;
using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService service = null;
        public InvoiceController(IInvoiceService service)
        {
            this.service = service;
        }


        [Route("~/api/sales/invoice/save")]
        [HttpPost]
        public async Task<ActionResult> saveSalesOrder([FromBody] InvoiceDto invoice)
        {
            try
            {

                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));
                return getResponse(await service.saveInvoice(invoice, getSessionUser()));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/pending/orders/detail/{OrderCode}")]
        public async Task<ActionResult> getOrderDetailForInvoice(string OrderCode)
        {
            try
            {                
                return getResponse(await service.getOrderDetailForInvoice(OrderCode, true));
            }
            catch (Exception ex) {return getResponse(ex);}
        }

        // VERSION : 2
        [HttpGet]
        [Route("~/api/sales/invoice/pending/orders/detail/{OrderCode}/{hascreditnoteadjustment}")]
        public async Task<ActionResult> getOrderDetailForInvoice(string OrderCode, Boolean hascreditnoteadjustment)
        {
            try
            {                
                return getResponse(await service.getOrderDetailForInvoice(OrderCode, hascreditnoteadjustment));
            }
            catch (Exception ex) {return getResponse(ex);}
        }



        [Route("~/api/sales/invoice/discount/policy/calculation/update")]
        [HttpPost]
        public async Task<ActionResult> updateBonusPolicyCalculation([FromBody] InvoiceDiscountUpdateRequestDto invoice)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));
                return getResponse(await service.applyBonusAndDiscountForInvoiceDetail(invoice.Details, invoice.ChemistCode, invoice.PaymentMode, invoice.HasCreditNoteAdjustment));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/location/wise/invoice/date/between/{fromdate}/{todate}/{paymentmode}/{locationcode}")]
        public async Task<ActionResult> getLocationWiseInvoiceDateBetween(string FromDate, string ToDate, string PaymentMode, string LocationCode)
        {
            try
            {
                return getResponse(await service.getLocationWiseInvoiceDateBetween(FromDate, ToDate, PaymentMode, LocationCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }




    }
}
