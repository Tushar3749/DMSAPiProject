using DMS.Core.DTO.Accounts;
using DMS.Core.Models.Accounts;
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

    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService service;

        public AccountsController(IAccountsService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Route("~/api/deposit/bank/list")]
        public async Task<ActionResult> getbanklist()
        {
            try
            {
                return getResponse(await service.getbanklist());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
        [HttpGet]
        [Route("~/api/deposit/chemist/bank/list")]
        public async Task<ActionResult> getChemistbanklist()
        {
            try
            {
                return getResponse(await service.getChemistbanklist());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/check/no/list")]
        public async Task<ActionResult> getInstrumentInfoList()
        {
            try
            {
                return getResponse(await service.getInstrumentInfoList());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/deposit/bankinfo/by/code/{bankcode}")]
        public async Task<ActionResult> getbankinfobybankcode(string bankcode)
        {
            try
            {
                return getResponse(await service.getbankinfobybankcode(bankcode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/deposit/type/list")]
        public async Task<ActionResult> getdeposittype()
        {
            try
            {
                return getResponse(await service.getdeposittypelist());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/deposit/info/save")]
        public async Task<ActionResult> savedeposit([FromBody] BankDepositDto deposit)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(deposit));
                return getResponse(await service.saveDeposit(deposit, this.getSessionUser()));

            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/accounts/collection/money/receipt/save")]
        public async Task<ActionResult> saveMoneyReceipt([FromBody] MoneyReceiptNewDto collection)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));
                return getResponse(await service.saveMoneyReceipt(collection, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/accounts/collection/detail/receipt/code/{MoneyReceiptCode}")]
        public async Task<ActionResult> getMoneyReceiptDetailsByMoneyReceiptCode(string MoneyReceiptCode)
        {
            try
            {
                return getResponse(await service.getMoneyReceiptDetailsByMoneyReceiptCode(MoneyReceiptCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/accounts/collection/cash")]
        public async Task<ActionResult> getSummaryPendingCollection()
        {
            try
            {
                return getResponse(await service.getSummaryPendingCollection());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/accounts/collection/cash/detail/{SummaryCode}")]
        public async Task<ActionResult> getSummaryPendingCollectionDetail(string SummaryCode)
        {
            try
            {
                return getResponse(await service.getSummaryPendingCollectionDetail(SummaryCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/accounts/collection/chemist/wise")]
        public async Task<ActionResult> getDueCollectionChemistWise()
        {
            try
            {
                return getResponse(await service.getDueCollectionChemistWise());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/accounts/collection/chemist/wise/detail/{ChemistCode}")]
        public async Task<ActionResult> getDueCollectionChemistWiseDetail(string ChemistCode)
        {
            try
            {
                return getResponse(await service.getDueCollectionChemistWiseDetail(ChemistCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/bank/deposit/detail/{depositCode}")]
        public async Task<ActionResult> getbankdepositDetail(string depositCode)
        {
            try
            {
                return getResponse(await service.getbankdepositDetail(depositCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/bank/deposit/list/{startdate}/{enddate}")]
        public async Task<ActionResult> getbankdepositlist(DateTime startdate, DateTime enddate)
        {
            try
            {
                return getResponse(await service.getbankdepositlist(startdate, enddate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/deposit/detail/info/{Id}")]
        public async Task<ActionResult> getbankdepositlistbyId(int Id)
        {
            try
            {
                return getResponse(await service.getbankdepositlistbyId(Id));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/get/latest/deposit")]
        public async Task<ActionResult> getLatestDeposit()
        {
            try
            {
                return getResponse(await service.getLatestDeposit());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        //Added By Siam
        //Added on 29 August 2021
        [HttpGet]
        [Route("~/api/money/receipt/{fromdate}/{todate}")]
        public async Task<ActionResult> getMoneyReceiptDateWise(string FromDate, string ToDate)
        {
            try
            {
                return getResponse(await service.getMoneyReceipt(FromDate, ToDate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/money/receipt/wise/{fromdate}/{todate}/{dacode}")]
        public async Task<ActionResult> getMoneyReceiptDAWise(string FromDate, string ToDate, string DACode)
        {
         

            try
            {
                return getResponse(await service.getMoneyReceiptDAWise(FromDate, ToDate, DACode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/money/receipt/by/code/{mrcode}")]
        public async Task<ActionResult> getMoneyReceiptByCode(string MRCode)
        {
            try
            {
                return getResponse(await service.getMoneyReceiptByCode(MRCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpPost]
        [Route("~/api/bank/info/save")]
        public async Task<ActionResult> savebankinfo([FromBody] List<Bank> deposit)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(deposit));
                return getResponse(await service.saveBankInfo(deposit));

            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
        [HttpPost]
        [Route("~/api/bank/inactive")]
        public async Task<ActionResult> InactiveBank([FromBody] Bank deposit)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(deposit));
                return getResponse(await service.InactiveBank(deposit));

            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
        [HttpPost]
        [Route("~/api/bank/active")]
        public async Task<ActionResult> ActiveBank([FromBody] Bank deposit)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                saveLog(new JSONSerialize().getJSONString(deposit));
                return getResponse(await service.ActiveBank(deposit));

            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
        //END Of Author Shamsul Hasan Siam


    }
}
