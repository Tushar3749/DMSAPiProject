using DMS.Core.DTO.Inventory;
using DMS.Core.DTO.Security;
using DMS.Core.DTO.User;
using DMS.Core.Models.Inventory;
using DMS.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Controllers
{
    [Authorize]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IstockService service;
        private readonly IInventoryService _invService;

        public InventoryController(IstockService service, IInventoryService invService)
        {
            this.service = service;
            this._invService = invService;
        }


        [HttpGet]
        [Route("~/api/stock/pending/approval/challan")]
        public async Task<IActionResult> getPendingApprovalChallanReceive()
        {
            try
            {
                return getResponse(await service.getPendingApprovalChallanReceive());
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/depot/inventory/get/available/stock")]
        public async Task<IActionResult> getCurrentStock()
        {
            try
            {
                return getResponse(await _invService.getCurrentStock());
            }
            catch (Exception ex) { return getResponse(ex); }
        }


        [HttpGet]
        [Route("~/api/stock/pending/received/challan")]
        public async Task<IActionResult> getApprovedChallanReceive()
        {
            try
            {
                return getResponse(await service.getApprovedChallanReceive());

            }

            catch (Exception ex) { return getResponse(ex); }
         
        }


        [HttpPost]
        [Route("~/api/stock/pending/approval/update")]
        public async Task<ActionResult> UpdateChallanApproved([FromBody] List<StockReceiveDTO> details)
        {
            try
            {
                var _User = this.getSessionUser();
                string user = _User.EmployeeID;

                if (!ModelState.IsValid) return BadRequest(ExceptionGroup.setMessage(ExceptionGroup.Allocation, "0.1", "Unable to fetch form data"));

                var data = await service.UpdateApprovedChallanList(details, user);

                if (data != null) 
                return getResponse(data);


                return BadRequest(new ErrorMessageDto { Code = "L-001.2", Title = "Login", Details = "Username or password is incorrect." });
            }
            catch (Exception ex) { return getResponse(ex); }


        }


        [Route("~/api/stock/pending/received/update/")]
        [HttpPost]
        public async Task<ActionResult> UpdateChallanReceived([FromBody] List<StockReceiveDTO> details)
        {
            try
            {
                var _User = this.getSessionUser();

                string user = _User.EmployeeID;

                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                var data = await service.UpdateReceivedChallanList(details, user);

                if (data != null)
                return getResponse(data);


                return BadRequest(new ErrorMessageDto { Code = "L-001.2", Title = "Login", Details = "Username or password is incorrect." });
            }
            catch (Exception ex) { return getResponse(ex); }


        }


        [HttpGet]
        [Route("~/api/inventory/depot/location/all/{IssueType}")]
        public async Task<ActionResult> getDepotLocation(string IssueType)
        {
            try
            {
                return getResponse(await _invService.getDepotLocaiton(IssueType));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/product/wtih/stock")]
        public async Task<ActionResult> getProductWithStock()
        {
            try
            {
                return getResponse(await _invService.getProductWithStock());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/depot/product/wtih/stock/{shortstockonly}")]
        public async Task<ActionResult> getProductWithStock(Boolean shortstockonly)
        {
            try
            {
                return getResponse(await _invService.getProductWithStock(shortstockonly));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/inventory/depot/issue/save/")]
        public async Task<ActionResult> SaveStockIssue([FromBody] DepotIssue issue)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                return getResponse(await _invService.saveDepotIssue(issue, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }

        }


        [HttpGet]
        [Route("~/api/inventory/depot/receive/credit/note/pending/list")]
        public async Task<ActionResult> getCreditNotePendingDto()
        {
            try
            {
                return getResponse(await _invService.getCreditNotePendingDto());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/receive/credit/note/pending/detail/{ReceiveCode}")]
        public async Task<ActionResult> getCreditNotePendingDetailDto(string ReceiveCode)
        {
            try
            {
                return getResponse(await _invService.getCreditNotePendingDetailDto(ReceiveCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/receive/credit/note/update/{ReceiveCode}")]
        public async Task<ActionResult> updateCreditNoteReceive(string ReceiveCode)
        {
            try
            {
                return getResponse(await _invService.updateCreditNoteReceive(ReceiveCode, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/issue/approval/list")]
        public async Task<ActionResult> getDepotIssueApprovalList()
        {
            try
            {
                return getResponse(await _invService.getDepotIssueApprovalList());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/issue/dispatch/list")]
        public async Task<ActionResult> getDepotIssueDispatchList()
        {
            try
            {
                return getResponse(await _invService.getDepotIssueDispatchList());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/depot/issue/approval/details/list/{IssueCode}")]
        public async Task<ActionResult> getDepotIssueApprovalDetailsList(string IssueCode)
        {
            try
            {
                return getResponse(await _invService.getDepotIssueApprovalDetailsList(IssueCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
      
        }


        [HttpPost]
        [Route("~/api/inventory/depot/issue/approved/update")]
        public async Task<ActionResult> UpdateDepotIssueApproved([FromBody] StockIssue issue)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));
                return getResponse(await _invService.SetStockIssueApprove(issue, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/inventory/depot/issue/dispatch/update")]
        public async Task<ActionResult> UpdateDepotIssueDispatch([FromBody] StockIssue issue)
        {
            try
            {
                StockIssue NewStockIssue = new StockIssue();

                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                var _User = this.getSessionUser();

                StockIssue StockIssue = await _invService.findoneDepotIssueById(issue.Id);

                NewStockIssue = await _invService.SetStockIssueDispatch(StockIssue, _User);

                return getResponse(await UpdateDepotIssue(NewStockIssue));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }

        }


        [HttpPost]
        [Route("~/api/inventory/depot/issue/update/")]
        public async Task<ActionResult> UpdateDepotIssue([FromBody] StockIssue issue)
        {
            try
            {
                if (!ModelState.IsValid) return getResponse(new Exception("Unable to fetch form data"));

                return getResponse(await _invService.updateDepotIssue(issue.Id, issue));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpPost]
        [Route("~/api/depot/inventory/pending/challan/receive/")]
        public async Task<ActionResult> saveDepotChallan([FromBody] ChallanReceivePendingDto challan)
        {
            try
            {
                return getResponse(await _invService.saveDepotChallan(challan, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }

        }



        [HttpGet]
        [Route("~/api/stock/issue/latest/{fromdate}/{todate}")]
        public async Task<IActionResult> getlateststockIssue(string fromdate, string todate)
        {
            try 
            {
            
                return getResponse(await _invService.getlateststockIssue( fromdate, todate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/stock/issue/by/searchtext/{searchText}")]
        public async Task<IActionResult> getstockIssueBySearchText(string searchText)
        {
            try
            {
                return getResponse(await _invService.getstockIssueBySearchText(searchText));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/stock/issue/details/by/issuecode")]
        public async Task<IActionResult> getstockIssueDetailsByIssueCode(string issueCode)
        {
            try
            {
                return getResponse(await _invService.getstockIssueDetailsByIssueCode(issueCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/stock/issue/total/val/details/by/issuecode")]
        public async Task<IActionResult> getstockIssueTotalValDetailsByIssueCode(string issueCode)
        {
            try
            {
                return getResponse(await _invService.getstockIssueTotalValDetailsByIssueCode(issueCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/stock/issue/findone/{issueCode}")]
        public async Task<IActionResult> findOneStockIssueByIssueCode(string issueCode)
        {
            try
            {
                return getResponse(await _invService.findOneStockIssueByIssueCode(issueCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/stock/issue/total/details/{issueCode}")]
        public async Task<IActionResult> getstockissueTotalandDetailsbyIssueCode(string issueCode)
        {
            try
            {
                return getResponse(await _invService.getstockissueTotalandDetailsbyIssueCode(issueCode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/inventory/available/stock/info")]
        public async Task<IActionResult> getAvailableStock()
        {
            try
            {
                return getResponse(await _invService.getAvailableStock());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/available/stock/info/date/between/{FromDate}/{ToDate}/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getAvailableStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getAvailableStockInfoDateBetween(FromDate, ToDate, ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/physical/stock/info/date/between/{FromDate}/{ToDate}/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getPhysicalStockInfoDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getPhysicalStockInfoDateBetween(FromDate, ToDate, ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }



        [HttpGet]
        [Route("~/api/inventory/physical/stock/info")]
        public async Task<IActionResult> getPhysicalStock()
        {
            try
            {
                return getResponse(await _invService.getPhysicalStock());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }


        [HttpGet]
        [Route("~/api/inventory/product/batch/reconciliation/stock/info/product/wise/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getBatchReconciliationStock(string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getBatchReconciliationStock(ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/product/batch/reconciliation/stock/info/batch/wise/date/between/{FromDate}/{ToDate}/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getBatchReconciliationStockDateBetween(string FromDate, string ToDate,string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getBatchReconciliationStockBatchWiseDateBetween( FromDate, ToDate, ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/product/batch/reconciliation/stock/info/product/wise/date/between/{FromDate}/{ToDate}/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getBatchReconciliationStockproductWiseDateBetween(string FromDate, string ToDate, string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getBatchReconciliationStockProductWiseDateBetween(FromDate, ToDate, ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/product/batch/reconciliation/stock/info/batch/wise/{ProductCode}/{BatchNo}")]
        public async Task<IActionResult> getBatchReconciliationStockBatchWise(string ProductCode, string BatchNo)
        {
            try
            {
                return getResponse(await _invService.getBatchReconciliationStockBatchWise(ProductCode, BatchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/stock/receive/list/{startdate}/{enddate}")]
        public async Task<IActionResult> getstockreceive(DateTime startdate, DateTime enddate)
        {
            try
            {
                return getResponse(await _invService.getlateststockReceive(startdate,enddate));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/stock/receive/total/details/{receivecode}")]
        public async Task<IActionResult> getstockreceiveTotalandDetailsbyIssueCode(string receivecode)
        {
            try
            {
                return getResponse(await _invService.getstockReceiveTotalandDetailsbyIssueCode(receivecode));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/get/issuetypes")]
        public async Task<IActionResult> getIssueTypes()
        {
            try
            {
                return getResponse(await _invService.getIssueTypes());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/stock/issue/for/sync")]
        public async Task<IActionResult> getStockIssueForSync()
        {
            try
            {
                return getResponse(await _invService.getStockIssueForSync());
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpPost]
        [Route("~/api/inventory/stock/issue/update/to/transfer")]
        public async Task<IActionResult> updateStockIssueToTransfer([FromBody] List<StockIssueForSyncDto> issue)
        {
            try
            {
                return getResponse(await _invService.updateStockIssueToTransfer(issue, this.getSessionUser()));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }

        [HttpGet]
        [Route("~/api/inventory/product/batch/reconciliation/stock/info/batch/wise/details/{batchNo}")]
        public async Task<IActionResult> getBatchReconciliationStockBatchWiseDetails(string batchNo)
        {
            try
            {
                return getResponse(await _invService.getBatchReconciliationStockBatchWiseDetails(batchNo));
            }
            catch (Exception ex)
            {
                return getResponse(ex);
            }
        }
    }
}
