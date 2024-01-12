/*
*=============================================
*Author: Shafiqul Bari Sadman
*Email: sadman.it@labaidpharma.com
*Created on: 7 - jun - 2021
*Updated on: 7 - jun - 2021
*Last updated on:
*Description: <>
*=============================================
*/



using DMS.Core.DTO.Allocation;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.Security;
using DMS.Core.DTO.User;
using DMS.Services.SalesInvoice;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceAllocationController : ControllerBase
    {
        private readonly IInvoiceAllocationService service;

        public InvoiceAllocationController(IInvoiceAllocationService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/list")]
        public async Task<IActionResult> getAllInvoiceAllocationList()
        {
            try
            {
                return getResponse(await service.GetAllInvoiceAllocationList());
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/list/{allocationCode}")]
        public async Task<IActionResult> GetInvoiceAllocationListByallocationCode(string allocationCode)
        {
            try
            {
                return getResponse(await service.GetInvoiceAllocationListByallocationCode(allocationCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/report/list/")]
        public async Task<IActionResult> getAllocationInvoiceReportList()
        {
            try
            {
                return getResponse(await service.getAllocationInvoiceReportList());
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/pending/allocation/list")]
        public async Task<IActionResult> getInvoiceForNewAllocation()
        {
            try
            {
                return getResponse(await service.getInvoiceForNewAllocation());
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/da/list")]
        public async Task<IActionResult> getDAListByDepot()
        {
            try
            {
                return getResponse(await service.getDAListByDepot());

            }catch (Exception ex) { return getResponse(ex); }
        }
        
        [HttpGet]
        [Route("~/api/invoice/allocation/findone/list/{allocationCode}")]
        public async Task<IActionResult> findOneAllocationInvoiceByallocationCode(string allocationCode)
        {
            try
            {
                return getResponse(await service.findOneAllocationInvoiceByallocationCode(allocationCode));

            }

            catch (Exception ex) { return getResponse(ex); }
        }

        [Route("~/api/invoice/allocation/save/")]
        [HttpPost]
        public async Task<ActionResult> saveAllocationInvoice([FromBody] InvoiceAllocationModelDto details)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ExceptionGroup.setMessage(ExceptionGroup.Allocation,"0.1", "Unable to fetch form data"));
                saveLog(new JSONSerialize().getJSONString(details));
                
                return getResponse(await service.saveInvoiceAllocation(details, this.getSessionUser()));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/list/by/da/{DACode}/{startdate}/{enddate}")]
        public async Task<IActionResult> GetInvoiceAllocationListByDACode(string DACode,DateTime startdate,DateTime enddate)
        {
            try
            {
                return getResponse(await service.getInvoiceAllocationByDACode(DACode,startdate,enddate));

            }

            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/statement/list/{DACode}/{startdate}/{enddate}/{status}")]
        public async Task<IActionResult> getAllocationInvoiceStatement(string DACode, DateTime startdate, DateTime enddate,string status)
        {
            try
            {
                return getResponse(await service.getAllocationInvoiceStatement(DACode, startdate, enddate,status));

            }

            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/summary/statement/list/{DACode}/{startdate}/{enddate}")]
        public async Task<IActionResult> getSummaryStatement(string DACode, DateTime startdate, DateTime enddate)
        {
            try
            {
                return getResponse(await service.getSummaryStatement(DACode, startdate, enddate));

            }

            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/invoice/summary/allocation/by/da/{DACode}/{startdate}/{enddate}")]
        public async Task<IActionResult> getSummaryAndAllocationListByDA(string DACode, DateTime startdate, DateTime enddate)
        {
            try
            {
                return getResponse(await service.getSummaryAndAllocationListByDA(DACode, startdate, enddate));

            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/summary/allocation/return/by/da/{DACode}/{startdate}/{enddate}")]
        public async Task<IActionResult> getSummaryAndAllocationReturnByDA(string DACode,DateTime startdate, DateTime enddate)
        {
            try
            {
                return getResponse(await service.getSummaryAndAllocationReturnByDA(DACode,startdate,enddate));
            }

            catch (Exception ex) 
            { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/details/by/code/{AllocationCode}")]
        public async Task<IActionResult> getAllocationDetailsByAllocationCode(string AllocationCode)
        {
            try
            {
                return getResponse(await service.getAllocationDetailsByAllocationCode(AllocationCode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/pending/dispatch/list")]
        public async Task<IActionResult> getPendingDispatchInvoiceAllocationList()
        {
            try
            {
                return getResponse(await service.getPendingDispatchInvoiceAllocationList());

            }catch (Exception ex) { return getResponse(ex); }
        }

        [HttpGet]
        [Route("~/api/invoice/allocation/invoice/chemist/by/{AllocationCode}")]
        public async Task<IActionResult> getInvoiceandChemistInfoByAllocationCode(string AllocationCode)
        {
            try
            {
                return getResponse(await service.getInvoiceandChemistInfoByAllocationCode(AllocationCode));

            }

            catch (Exception ex) { return getResponse(ex); }

        }

        [Route("~/api/invoice/allocation/dispatch/")]
        [HttpPost]
        public async Task<ActionResult> DispatchAllocation([FromBody] InvoiceAllocationDTO allocation)
        {
            try
            {
                var _User = this.getSessionUser();
                string userId = _User.EmployeeID;

                if (!ModelState.IsValid) return BadRequest(ExceptionGroup.setMessage(ExceptionGroup.Allocation, "0.1", "Unable to fetch form data"));


                var result = await service.updateInvoiceAllocation(allocation, userId);

                if (result != null) 
                    
                return getResponse(result);

                return BadRequest(new ErrorMessageDto { Code = "L-001.2", Title = "Login", Details = "Username or password is incorrect." });
            }

            catch (Exception ex) { return getResponse(ex); }


        }

        [HttpGet]
        [Route("~/api/allocated/list/by/da/{DAcode}")]
        public async Task<IActionResult> getpendingallocatedlist(string DAcode)
        {
            try
            {
                return getResponse(await service.GetSummaryPendingAllocationListByDACode(DAcode));
            }
            catch (Exception ex) { return getResponse(ex); }
        }
    }
}
