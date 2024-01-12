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

using DMS.Core.Dto.User;
using DMS.Core.DTO.Allocation;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.Security;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Map.SalesInvoice;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Services.SalesInvoice
{

    public class InvoiceAllocationService : LoggerService, IInvoiceAllocationService
    {
        private DbContext context;

        public Exception error = new Exception();
        private InvoiceAllocationRepository repo;

        private InvoiceAllocationDetailRepository detailrepo;
        private readonly CodeGenerateRepository codeRepo = null;

        public InvoiceAllocationService(IConfiguration Config)
        {
            this.context = new InvoiceContext(Config);
            this.repo = new InvoiceAllocationRepository(this.context);
            this.detailrepo = new InvoiceAllocationDetailRepository(this.context);

            this.codeRepo = new CodeGenerateRepository(this.context);

        }
        public async Task<List<InvoiceAllocationDTO>> GetAllInvoiceAllocationList()
        {
            
                return await repo.getInvoiceAllocation();

        }
        public async Task<List<PendingAllocationDispatchDTO>> getPendingDispatchInvoiceAllocationList()
        {
            try
            {
                return await repo.getPendingDispatchInvoiceAllocationList();
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        
        public async Task<List<InvoiceAllocationDTO>> GetInvoiceAllocationListByallocationCode(string allocationCode)
        {
            return await repo.getInvoiceAllocationByallocationCode(allocationCode);
   
        }
        public async Task<InvoiceAllocation> findOneAllocationInvoiceByallocationCode(string allocationCode)
        {
            
                return await repo.findOneAllocationInvoiceByallocationCode(allocationCode);
            
        }

        public async Task<List<InvoiceAllocation>> getAllocationInvoiceReportList()
        {
            return await repo.getAllocationInvoiceReportList();
        }

        public async Task<List<PendingInvoiceAllocationDTO>> getInvoiceForNewAllocation()
        {
            return await repo.getInvoiceForNewAllocationList();
        }

        public async Task<List<DAListDTO>> getDAListByDepot()
        {
            return await repo.getDAListByDepot("ALLOCATION");
        }

        public async Task<InvoiceAllocation> saveInvoiceAllocation(InvoiceAllocationModelDto Allocation, UserBasicInfo User)
        {

            await validateInvoiceAllocation(Allocation);

            InvoiceAllocation allocation = new InvoiceAllocation();
            List<InvoiceAllocationDetail> invAllocationDetail = new List<InvoiceAllocationDetail>();

            if (!Allocation.AllocationInvoice.Any()) throw new Exception("Failed to map.Please try again");
            var detail = Allocation.AllocationInvoice;


            string allocationCode = await codeRepo.getGeneratedCode("ALLOCATION");

            foreach (var item in detail)
            {

                item.AllocationCode = allocationCode; //await GenerateAllocationCode("DHK");
                item.MachineID = "";
                item.IsActive = true;
                item.CreatedOn = DateTime.Now;
                item.UpdatedOn = DateTime.Now;

                item.ID = null;

                InvoiceAllocationDetail newItem = new InvoiceAllocationDetailsMap().map(item);

                allocationCode = item.AllocationCode;
                invAllocationDetail.Add(newItem);
            }

            //map to invoice allocation
            allocation.AllocationCode = allocationCode;
            allocation.AllocationDate = DateTime.Now;
            allocation.Dacode = Allocation.DACode;
            allocation.DepotCode = User.DepotCode;
            allocation.ReturnDate = Convert.ToDateTime(Allocation.ReturnDate);
            allocation.MachineId = "La Machina";
            allocation.IsDispatched = false;
            allocation.IsActive = true;
            allocation.CreatedOn = DateTime.Now;
            allocation.UpdatedOn = DateTime.Now;

            if (detail.Count > 0)
            {
                allocation.CreatedById = detail.FirstOrDefault().CreatedByID;
                allocation.UpdatedById = detail.FirstOrDefault().UpdatedByID;

                allocation.Dacode = detail.FirstOrDefault().DACode; 

            }


            //SAVE

            var newAllocation = await repo.saveInvoiceAllocation(allocation);

            foreach (var item in invAllocationDetail)
            {
               
              var allocationdetail = await repo.UpdateInvoiceAllocationAndInvoice(item.InvoiceCode);
                
            }
            invAllocationDetail = await detailrepo.saveBulk(invAllocationDetail);

            //END SAVE
            await repo.COMMIT();

            return newAllocation;
         
        }


        private async Task<Boolean> validateInvoiceAllocation(InvoiceAllocationModelDto Allocation)
        {
            foreach (var invoice in Allocation.AllocationInvoice)
            {
                var activeAllocation = await repo.getAllocatedActiveInvoice(invoice.InvoiceCode);
                if(activeAllocation != null) throw new Exception($"Failed to save allocation. Active allocation found for this invoice : {invoice.InvoiceCode}, Allocation Code:  {activeAllocation.AllocationCode} ");
            }

            return true;
        }


        public async Task<List<InvoiceAllocation>> GetSummaryPendingAllocationListByDACode(string DAcode)
        {
            
            return await repo.getSummaryPendingInvoiceAllocationByDA(DAcode);
            
        }
        public async Task<List<InvoiceAllocation>> getInvoiceAllocationByDACode(string DAcode, DateTime startdate, DateTime enddate)
        {
            try
            {
                enddate = ExtentionMethods.ExtentionMethods.SetMaxDatetime(enddate);

                if (String.IsNullOrEmpty(DAcode) || DAcode == "Select DA") return await repo.getInvoiceAllocationByDate(startdate, enddate);
                else return await repo.getInvoiceAllocationByDACode(DAcode,startdate,enddate);
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }
        public async Task<List<AllocationInvoiceStatementDTO>> getAllocationInvoiceStatement(string DAcode, DateTime startdate, DateTime enddate, string status)
        {            
            enddate = ExtentionMethods.ExtentionMethods.SetMaxDatetime(enddate);
            return await repo.getAllocationInvoiceStatement(DAcode,startdate, enddate, status);
            
        }

        public async Task<List<SummaryStatementDTO>> getSummaryStatement(string DAcode, DateTime startdate, DateTime enddate)
        {
            
            enddate = ExtentionMethods.ExtentionMethods.SetMaxDatetime(enddate);

            return await repo.getSummaryStatement(startdate, enddate, DAcode);
           
        }
        public async Task<List<ProductReturnReportDTO>> getSummaryAndAllocationListByDA(string DACode, DateTime startdate, DateTime enddate)
        {
            
            enddate = ExtentionMethods.ExtentionMethods.SetMaxDatetime(enddate);

            return await repo.getSummaryAndAllocationByDA(DACode, startdate, enddate);
            
        }
        public async Task<List<ProductReturnReportDTO>> getSummaryAndAllocationReturnByDA(string DACode, DateTime startdate, DateTime enddate)
        {
            
            enddate = ExtentionMethods.ExtentionMethods.SetMaxDatetime(enddate);
            return await repo.getSummaryAndAllocationReturnByDA(DACode,startdate,enddate);
            
        }
        public async Task<InvoiceAllocation> updateInvoiceAllocation(InvoiceAllocationDTO invoiceAllocation,string UserId)
        {
            

            InvoiceAllocation allocationDTO = await findOneAllocationInvoiceByallocationCode(invoiceAllocation.AllocationCode);

            if(allocationDTO == null)
            {
                throw new Exception($"Allocation does not exists.Couldn't find Allocation using the following code: {invoiceAllocation.AllocationCode}. Please verify or refresh");                
            }

            allocationDTO.IsDispatched = true;
            allocationDTO.DispatchedOn = DateTime.Now;
            allocationDTO.DispatchedById = UserId;
            allocationDTO.Remarks = invoiceAllocation.Remarks;

            return await repo.updateInvoiceAllocation(allocationDTO);
            
        }
        public async Task<List<InvoiceAllocationDispatchDTO>> getAllocationDetailsByAllocationCode(string AllocationCode)
        {
            
                return await repo.getAllocationDetailsByAllocationCode(AllocationCode);
           
        }
        public async Task<List<InvoiceAllocationDispatchMasterDTO>> getInvoiceandChemistInfoByAllocationCode(string AllocationCode)
        {
            
                // Getting All invoice data
                List<InvoiceAllocationDispatchMasterDTO> master = await repo.getInvoiceandChemistInfoByAllocationCode(AllocationCode);
                
                // Getting all invoice detail data
                List<InvoiceAllocationDispatchDTO> detail =  await repo.getAllocationDetailsByAllocationCode(AllocationCode);
                
                // mapping and initializing invoice data with invoice invoice detail data

             //   master.AsEnumerable().All(c => { c.InvoiceAllocationDispatchDTO = new List<InvoiceAllocationDispatchDTO>();
             //   c.InvoiceAllocationDispatchDTO.AddRange(detail.AsEnumerable().Where(x => (x.InvoiceCode == c.InvoiceCode)).ToList());
             //   return true; });
                
                return master;
           
        }

        public  bool findallocationInSummary(string AllocationCode)
        {
            bool res = repo.findallocationInSummary(AllocationCode);

            return res;
        }
    }
}
