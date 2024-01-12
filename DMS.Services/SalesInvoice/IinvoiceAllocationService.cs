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
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.SalesInvoice
{
   public interface IInvoiceAllocationService
    {
        Task<List<InvoiceAllocationDTO>> GetAllInvoiceAllocationList();
        Task<List<InvoiceAllocationDTO>> GetInvoiceAllocationListByallocationCode(string allocationCode);
        Task<InvoiceAllocation> findOneAllocationInvoiceByallocationCode(string allocationCode);
        Task<List<InvoiceAllocation>> getAllocationInvoiceReportList();

        Task<List<PendingInvoiceAllocationDTO>> getInvoiceForNewAllocation();

        Task<List<DAListDTO>> getDAListByDepot();

        Task<InvoiceAllocation> saveInvoiceAllocation(InvoiceAllocationModelDto newData, UserBasicInfo User);

        Task<List<InvoiceAllocation>> GetSummaryPendingAllocationListByDACode(string DAcode);
        Task<List<InvoiceAllocationDispatchDTO>> getAllocationDetailsByAllocationCode(string AllocationCode);
        
        Task<List<PendingAllocationDispatchDTO>> getPendingDispatchInvoiceAllocationList();

        Task<InvoiceAllocation> updateInvoiceAllocation(InvoiceAllocationDTO invoiceAllocation,string UserId);

        Task<List<InvoiceAllocationDispatchMasterDTO>> getInvoiceandChemistInfoByAllocationCode(string AllocationCode);

        bool findallocationInSummary(string AllocationCode);

        Task<List<ProductReturnReportDTO>> getSummaryAndAllocationListByDA(string DACode, DateTime startdate, DateTime enddate);

        Task<List<ProductReturnReportDTO>> getSummaryAndAllocationReturnByDA(string DACode, DateTime startdate, DateTime enddate);

        Task<List<InvoiceAllocation>> getInvoiceAllocationByDACode(string DAcode, DateTime startdate, DateTime enddate);
        Task<List<AllocationInvoiceStatementDTO>> getAllocationInvoiceStatement(string DAcode, DateTime startdate, DateTime enddate ,string status);
        Task<List<SummaryStatementDTO>> getSummaryStatement(string DAcode, DateTime startdate, DateTime enddate);
    }
}
