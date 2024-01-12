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
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionReportController : ControllerBase
    {

        private readonly IAccountsService service;

        public CollectionReportController(IAccountsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/summary/collection/location/wise/{LocationCode}/{DateFrom}/{DateTo}/{PaymentMode}")]
        public async Task<ActionResult> getCollectionLocationWiseReport(string LocationCode, string DateFrom, string DateTo, string PaymentMode)
        {
            try
            {
                return getResponse(await service.getLocationWiseCollectionReport(LocationCode, DateFrom, DateTo, PaymentMode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

    }

  
}
