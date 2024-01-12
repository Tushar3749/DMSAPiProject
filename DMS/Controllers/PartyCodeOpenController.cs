using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DMS.Core.Models.PartyCode;
using System.Collections.Generic;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class PartyCodeOpenController : ControllerBase
    {
        private readonly IChemistService service;
        public PartyCodeOpenController(IChemistService partyCodePullService)
        {
            service = partyCodePullService;
        }

        [HttpPost]
        [Route("~/api/depot/party/code/data/update")]
        public async Task<ActionResult> saveChemistInvoiceAllowedDuration([FromBody] List<ChemistInvoiceAllowedDuration> chemistInvoiceAllowedDuration)
        {
            try
            {
                return getResponse(await service.UpdatePendingPartycodeToTransfer(chemistInvoiceAllowedDuration));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }

        }
    }
}
