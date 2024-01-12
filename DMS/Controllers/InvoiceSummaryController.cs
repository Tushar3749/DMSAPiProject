using DMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DMS.Utility.Library;
using DMS.Core.DTO.User;
using DMS.Core.DTO.SalesInvoice;

namespace DMS.Controllers
{
    public class InvoiceSummaryController : ControllerBase
    {
        private readonly IInvoiceSummaryService service = null;
        public InvoiceSummaryController(IInvoiceSummaryService service)
        {
            this.service = service;
        }

        // will be removed
        [HttpGet]
        [Route("~/api/sales/invoice/summary/pending/allocation/list")]
        public async Task<ActionResult> getSummaryPendingInvoiceAllocaiton()
        {
            try
            {
                return getResponse(await service.getSummaryPendingInvoiceAllocaiton());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/sales/allocation/for/return/summary")]
        public async Task<ActionResult> getAllocationForSummaryReturn()
        {
            try
            {
               return getResponse(await service.getAllocationForSummaryReturn());
            }
            catch (Exception ex){return getResponse(ex);}
        }


        [HttpGet]
        [Route("~/api/sales/invoice/summary/pending/allocation/detail/{allocationCode}")]
        public async Task<ActionResult> getSummaryPendingInvoiceAllocaitonDetail(string allocationCode)
        {
            try
            {
                return getResponse(await service.getSummaryPendingInvoiceAllocaitonDetail(allocationCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/summary/pending/allocation/invoice/detail/{invoiceCode}")]
        public async Task<ActionResult> getSummaryPendingAllocaitonInvoiceProductDetail(string invoiceCode)
        {
            try
            {
                return getResponse(await service.getSummaryPendingAllocaitonInvoiceProductDetail(invoiceCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        //[HttpPost]
        //[Route("~/api/sales/invoice/summary/pending/allocation/invoice/save")]
        //public async Task<ActionResult> saveInvoiceSummary([FromBody] SummaryDto summary)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

        //        saveLog(new JSONSerialize().getJSONString(summary));
                
        //        return getResponse(await service.saveInvoiceSummary(summary, this.getSessionUser()));
        //    }
        //    catch (Exception ex)
        //    {
        //        return getResponse(ex);
        //    }
        //}


        [HttpGet]
        [Route("~/api/sales/invoice/summary/pending/product/receive")]
        public async Task<ActionResult> getProductReceivePendingSummary()
        {
            try
            {
                return getResponse(await service.getProductReceivePendingSummary());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/summary/pending/product/receive/detail/{SummaryCode}/{AllocationCode}/{InvoiceCode}")]
        public async Task<ActionResult> getProductReceivePendingSummaryDetail(string SummaryCode, string AllocationCode, string InvoiceCode)
        {
            try
            {
                return getResponse(await service.getProductReceivePendingSummaryDetail(SummaryCode, AllocationCode, InvoiceCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/sales/invoice/summary/pending/return/invoice/product/receive")]
        public async Task<ActionResult> ReceiveBatchProduct([FromBody] List<ProductReceivePendingSummaryDetail> receive)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(receive));

                return getResponse(await service.receiveBatchProduct(receive, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageDto { Code = "G-001.1", Title = "Login", Details = ex.Message });
            }
        }


        [HttpGet]
        [Route("~/api/sales/invoice/summary/finalize/allocation/{AllocationCode}")]
        public async Task<ActionResult> finalizeAllocationSummary(string AllocationCode)
        {
            try
            {
                return getResponse(await service.finalizeAllocationSummary(AllocationCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/sales/invoice/summary/received/ait/documents")]
        public async Task<ActionResult> getReceivedAITDocument()
        {
            try
            {
                return getResponse(await service.getReceivedAITDocument());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/sales/invoice/summary/receive/pending/ait/documents")]
        public async Task<ActionResult> getReceivePendingAITDocument()
        {
            try
            {
                return getResponse(await service.getReceivePendingAITDocument());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
    }
}
