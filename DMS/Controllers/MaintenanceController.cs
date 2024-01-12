using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService service;

        public MaintenanceController(IMaintenanceService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/validate/support/task/ref/code/{TaskID}/{RefID}")]
        public async Task<ActionResult> getvalidateSupportTaskRefCode(int TaskID, string RefID)
        {
            try
            {
                return getResponse(await service.getvalidateSupportTaskRefCode(TaskID, RefID));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }

        }

        [HttpGet]
        [Route("~/api/validate/database/backup/for/day/close/{reportdate}")]
        public async Task<ActionResult> validateDatabaseBackupLog(string reportdate)
        {
            try
            {
                return getResponse(await service.validateDatabaseBackupLog(reportdate));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
    }
}
