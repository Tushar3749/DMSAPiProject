using DMS.Services.Interfaces;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
            
        }

        [Route("~/api/product/list")]
        [HttpGet]
        public async Task<ActionResult> getProducts()
        {            
            try
            {
                return getResponse(await service.getProducts());
            }
            catch(Exception ex)
            {
                return getResponse(ex);
            }
        }

        
        [Route("~/api/chemist/territory/history/{searchText}/{startdate}/{enddate}")]
        [HttpGet]
        public async Task<ActionResult> getChemistTerritoryHistory(string startdate, string enddate, string searchText)
        {
            try
            {
                var data = await service.getChemistTerritoryHistory(startdate, enddate, searchText);
                return Ok(new JSONSerialize().getJSONString(data));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

    }
}
