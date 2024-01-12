using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using DMS.Services.Interfaces;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class CreditNoteController : ControllerBase
    {

        private readonly ICreditNoteService creditNoteService;
        public CreditNoteController(ICreditNoteService creditNoteService)
        {
            this.creditNoteService = creditNoteService;
        }

        [HttpGet]
        [Route("~/api/credit/note/report/approved/money")]
        public async Task<ActionResult> getCreditNoteAdjustmentPending()
        {
            try
            {
                return getResponse(await creditNoteService.getCreditNoteAdjustmentPending());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/credit/note/report/aprroved/money/details/{depoCode}/{chemistCode}")]
        public async Task<ActionResult> getChemistCreditNoteAprrovedMoneyDetails(string depoCode, string chemistCode)
        {

            try
            {
                return getResponse(await creditNoteService.getChemistCreditNoteAprrovedMoneyDetails(depoCode, chemistCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/credit/note/report/adjusted/money")]
        public async Task<ActionResult> getCreditNoteAdjustedMoneyInfo()
        {
            try
            {
                return getResponse(await creditNoteService.getCreditNoteAdjustedMoney());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/credit/note/report/adjusted/money/details/{chemistCode}")]
        public async Task<ActionResult> getChemistCreditNoteAdjustedMoneyDetails(string chemistCode)
        {

            try
            {
                return getResponse(await creditNoteService.getChemistCreditNoteAdjustedMoneyDetails(chemistCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/credit/note/chemist/approved/total/amount/{chemistCode}")]
        public async Task<ActionResult> getChemistAprrovedTotalAmount(string chemistCode)
        {

            try
            {
                return getResponse(await creditNoteService.getChemistAprrovedTotalAmount(chemistCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
    }
}
