using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class DepoDayStatementController : ControllerBase
    {
        private readonly IDepoDayStatementService service;


        public DepoDayStatementController(IDepoDayStatementService service)
        {
            this.service = service;
        }


        [HttpGet]
        [Route("~/api/depot/daily/operational/status")]
        public async Task<ActionResult> getDayOpenAndCloseStatement()
        {
            try
            {
                return getResponse(await service.getDepotDayOperationStatus());
            }
            catch (Exception ex){return getResponse(ex);}
        }


        [HttpGet]
        [Route("~/api/depot/daily/operational/status/open/{employeeid}")]
        public async Task<ActionResult> OperationalDayOpen(string employeeid)
        {
            try
            {
                return getResponse(await service.updateDepotDayOperationStatus(employeeid, false));
            }
            catch (Exception ex){ return getResponse(ex);}
        }

        [HttpGet]
        [Route("~/api/depot/daily/operational/status/close/{employeeid}")]
        public async Task<ActionResult> OperationalDayClose(string employeeid)
        {
            try
            {
                return getResponse(await service.updateDepotDayOperationStatus(employeeid, false));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/depot/daily/operational/status/reopen/{employeeid}")]
        public async Task<ActionResult> OperationalDayReOpen(string employeeid)
        {
            try
            {
                return getResponse(await service.updateDepotDayOperationStatus(employeeid, true));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/depot/daily/operational/status/process/data/{ReportDate}")]
        public async Task<ActionResult> ProcessDayClosing(string ReportDate)
        {
            try
            {
                return getResponse(await service.ProcessDayClosing(ReportDate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/depot/operational/status/process/report/data")]
        public async Task<ActionResult> ProcessReportData()
        {
            try
            {
                return getResponse(await service.ProcessReportData());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        //Added By Monir
        //Added On 29 Aug 2022
        [HttpGet]
        [Route("~/api/depot/info/{DepoCode}")]

        public async Task<ActionResult> getDepoInfoByCode(string depoCode)
        {
            try
            {
                return getResponse(await service.getDepoInfoByCode(depoCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        //End of Author Monir

        
    }
}


    


