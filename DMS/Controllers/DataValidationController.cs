using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataValidationController : ControllerBase
    {
        private readonly IDataValidationService service = null;
        public DataValidationController(IDataValidationService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/validate/depot/wise/sales/{datefrom}/{dateto}")]
        public async Task<ActionResult> getValidateDepotWiseSales(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.getValidateDepotWiseSales(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/validate/invoice/wise/sales/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_InvoiceWiseSales(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_InvoiceWiseSales(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        
        [HttpGet]
        [Route("~/api/validate/territory/wise/sales/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_TerritoryWiseInvoice(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_TerritoryWiseInvoice(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
                
        [HttpGet]
        [Route("~/api/validate/area/wise/sales/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_AreaWiseInvoice(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_AreaWiseInvoice(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
                
        [HttpGet]
        [Route("~/api/validate/region/wise/sales/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_RegionWiseInvoice(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_RegionWiseInvoice(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/invoice/wise/collection/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_InvoiceWiseCollection(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_InvoiceWiseCollection(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/territory/wise/collection/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_TerritoryWiseCollection(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_TerritoryWiseCollection(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/area/wise/collection/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_AreaWiseCollection(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_AreaWiseCollection(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
        
        [HttpGet]
        [Route("~/api/validate/region/wise/collection/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_RegionWiseCollection(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_RegionWiseCollection(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/invoice/wise/outstanding/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_InvoiceWiseOutstanding(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_InvoiceWiseOutstanding(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/territory/wise/outstanding/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_TerritoryWiseOutstanding(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_TerritoryWiseOutstanding(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/area/wise/outstanding/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_AreaWiseOutstanding(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_AreaWiseOutstanding(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/validate/region/wise/outstanding/{datefrom}/{dateto}")]
        public async Task<ActionResult> dataValidation_RegionWiseOutstanding(string datefrom, string dateto)
        {
            try
            {
                return getResponse(await service.dataValidation_RegionWiseOutstanding(datefrom, dateto));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
    }
}
