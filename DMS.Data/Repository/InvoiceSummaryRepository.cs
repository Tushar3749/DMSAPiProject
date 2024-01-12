using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SummaryInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class InvoiceSummaryRepository : Repository
    {
        //private GenericRepository<InvoiceAllocation> invallo = null;
        private DbContext context = null;
        public InvoiceSummaryRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        // will be removed
        public async Task<List<SummaryPendingInvoiceAllocationDto>> getSummaryPendingInvoiceAllocaiton()
        {
            return await new GenericRepository<SummaryPendingInvoiceAllocationDto>(this.context).FindUsingSPAsync("exec getSummaryPendingAllocaitons", null);
        }
        public async Task<List<SummaryPendingInvoiceAllocationDto>> getAllocationForSummaryReturn()
        {
            return await new GenericRepository<SummaryPendingInvoiceAllocationDto>(this.context).FindUsingSPAsync("exec getAllocationForSummaryReturn", null);
        }

        public async Task<List<SummaryPendingInvoiceAllocationDetailDto>> getSummaryPendingInvoiceAllocaitonDetail(string allocationCode)
        {
            return await this.context.Set<SummaryPendingInvoiceAllocationDetailDto>().FromSqlRaw("exec getSummaryPendingAllocaitonsDetails @AllocationCode", new SqlParameter("@AllocationCode", allocationCode)).ToListAsync();
        }

        public async Task<List<InvoiceDetailSummaryDto>> getSummaryPendingAllocaitonInvoiceProductDetail(string invoiceCode)
        {
            return await this.context.Set<InvoiceDetailSummaryDto>().FromSqlRaw("exec getSummaryPendingAllocaitonInvoiceDetail @InvoiceCode", new SqlParameter("@InvoiceCode", invoiceCode)).ToListAsync();
        }

        public async Task<Summary> getSummaryByAllocationCode(string AllocationCode)
        {
            return await new GenericRepository<Summary>(this.context).FindOne(i => i.AllocationCode == AllocationCode && i.IsActive == true);
        }

        public async Task<Summary> insertSummary(Summary entity)
        {
            return await new GenericRepository<Summary>(this.context).Insert(entity);
        }

        public async Task<SummaryInvoice> insertInvoiceSummary(SummaryInvoice entity)
        {
            return await new GenericRepository<SummaryInvoice>(this.context).Insert(entity);
        }

        public async Task<List<SummaryInvoice>> insertInvoiceSummaryBulk(List<SummaryInvoice> entity)
        {
            return await new GenericRepository<SummaryInvoice>(this.context).InsertBulk(entity);
        }

        public async Task<SummaryInvoiceDetail> insertInvoiceDetailSummary(SummaryInvoiceDetail entity)
        {
            return await new GenericRepository<SummaryInvoiceDetail>(this.context).Insert(entity);
        }

        public async Task<SummaryCollection> insertSummaryCollection(SummaryCollection entity)
        {
            return await new GenericRepository<SummaryCollection>(this.context).Insert(entity);
        }

        public async Task<List<SummaryInvoiceDetail>> insertInvoiceDetailSummaryAll(List<SummaryInvoiceDetail> entity)
        {
            return await new GenericRepository<SummaryInvoiceDetail>(this.context).InsertBulk(entity);
        }

        public async Task<List<SummaryCollectionDetail>> insertSummaryCollecitonDetail (List<SummaryCollectionDetail> entity)
        {
            return await new GenericRepository<SummaryCollectionDetail>(this.context).InsertBulk(entity);
        }

        public async Task<List<SummaryCollectionInstrument>> insertSummaryCollecitonInstrument(List<SummaryCollectionInstrument> entity)
        {
            return await new GenericRepository<SummaryCollectionInstrument>(this.context).InsertBulk(entity);
        }

        public async Task<List<SummaryInvoiceProductBatchWise>> insertInvoiceProductBatchWiseSummaryAll(List<SummaryInvoiceProductBatchWise> entity)
        {
            return await new GenericRepository<SummaryInvoiceProductBatchWise>(this.context).InsertBulk(entity);
        }

        public async Task<List<ProductReceivePendingSummary>> getProductReceivePendingSummary()
        {
            return await this.context.Set<ProductReceivePendingSummary>().FromSqlRaw("exec getSummaryInvoiceReturnPending").ToListAsync();
        }

        public async Task<List<ProductReceivePendingSummaryDetail>> getProductReceivePendingSummaryDetail(string SummaryCode, string AllocationCode, string InvoiceCode)
        {
            return await this.context.Set <ProductReceivePendingSummaryDetail>().FromSqlRaw("exec getSummaryInvoiceDetail @SummaryCode, @AllocationCode, @InvoiceCode", new SqlParameter("@SummaryCode", SummaryCode), new SqlParameter("@AllocationCode", AllocationCode), new SqlParameter("@InvoiceCode", InvoiceCode)).ToListAsync();
        }

        public async Task<List<SummaryInvoiceProductBatchWise>> getInvoiceProductBatchWiseSummary(string SummaryCode, string InvoiceCode, string ProductCode)
        {
            return await new GenericRepository<SummaryInvoiceProductBatchWise>(this.context).Find(i => i.SummaryCode == SummaryCode && i.InvoiceCode == InvoiceCode && i.ProductCode == ProductCode);
        }

        public async Task<SummaryInvoice> getInvoiceSummary(string SummaryCode, string InvoiceCode)
        {
            return await new GenericRepository<SummaryInvoice>(this.context).FindOne(i => i.SummaryCode == SummaryCode && i.InvoiceCode == InvoiceCode && i.IsActive == true);
        }

        public async Task<SummaryInvoice> updateInvoiceSummary(SummaryInvoice entity)
        {
            return await new GenericRepository<SummaryInvoice>(this.context).Update(entity, i => i.Id == entity.Id);
        }

        public async Task<List<SummaryInvoiceProductBatchWise>> getInvoiceProductBatchSummary(string SummaryCode, string InvoiceCode)
        {
            return await new GenericRepository<SummaryInvoiceProductBatchWise>(this.context).Find(i => i.SummaryCode == SummaryCode && i.InvoiceCode == InvoiceCode);
        }

        public async Task<SummaryInvoiceProductBatchWise> updateInvoiceProductBatchSummary(SummaryInvoiceProductBatchWise entity)
        {
            return await new GenericRepository<SummaryInvoiceProductBatchWise>(this.context).Update(entity, c => c.SummaryCode == entity.SummaryCode && c.InvoiceCode == entity.InvoiceCode && c.ProductCode == entity.ProductCode && c.BatchNo == entity.BatchNo);
        }

        public async Task<Summary> getSummaryAllocations(string allocationCode)
        {
            return await new GenericRepository<Summary>(this.context).FindOne(i => i.AllocationCode == allocationCode );
        }

        public async Task<List<Summary>> insertAllocationSummary(string allocationCode, string EmployeeID, string MachineID)
        {
            return await this.context.Set<Summary>().FromSqlRaw("exec CreateInvoiceSummaryByAllocationCode @AllocaitonCode, @EmployeeCode, @MachineID", 
                new SqlParameter("@AllocaitonCode", allocationCode), new SqlParameter("@EmployeeCode", EmployeeID), new SqlParameter("@MachineID", MachineID)).ToListAsync();
        }

        public async Task<bool> updateInvoiceSummary(string InvoiceCode)
        {
            return await new GenericRepository<Summary>(this.context).ExecuteCommand("EXEC updateInvoiceSummaryToInActive @InvoiceCode", new SqlParameter("@InvoiceCode", InvoiceCode));
        }

        public async Task<bool> updateInvoiceDetailSummary(string InvoiceCode)
        {
            return await new GenericRepository<Summary>(this.context).ExecuteCommand("EXEC updateInvoiceDetailSummaryToInActive @InvoiceCode", new SqlParameter("@InvoiceCode", InvoiceCode));
        }

        public async Task<Summary> updateSummary(Summary summary)
        {
            return await new GenericRepository<Summary>(this.context).Update(summary, i => i.SummaryCode == summary.SummaryCode);
        }

        public async Task<SummaryInvoiceDetail> updateInvoiceDetailSummaryReturnQty(SummaryInvoiceDetail entity)
        {
            return await new GenericRepository<SummaryInvoiceDetail>(this.context).Update(entity, c => c.SummaryCode == entity.SummaryCode && c.InvoiceCode == entity.InvoiceCode && c.ProductCode == entity.ProductCode && c.IsActive ==  true);
        }

        public async Task<SummaryInvoiceDetail> getInvoiceDetailSummary(string SummaryCode, string InvoiceCode, string ProductCode)
        {
            return await new GenericRepository<SummaryInvoiceDetail>(this.context).FindOne(i => i.SummaryCode == SummaryCode && i.InvoiceCode == InvoiceCode && i.ProductCode == ProductCode && i.IsActive == true);
        }

        public async Task<List<AITDocumentReceiveStatusDTO>> getReceivedAITDocument()
        {
            return await this.context.Set<AITDocumentReceiveStatusDTO>().FromSqlRaw("exec getReceivedAITDocument").ToListAsync();
        }

        public async Task<List<AITDocumentReceiveStatusDTO>> getReceivePendingAITDocument()
        {
            return await this.context.Set<AITDocumentReceiveStatusDTO>().FromSqlRaw("exec getReceivePendingAITDocument").ToListAsync();
        }

        public async Task<bool> updateDepotSoldAvailableStock()
        {
            return await new GenericRepository<Summary>(this.context).ExecuteCommand("EXEC Inventory_DMS.dbo.updateDepotSoldQuantityToAvailableStock");
        }

        public async Task<List<UnadjustedCreditNoteListDto>> getUnadjustedCreditNoteList()
        {
            return await this.context.Set<UnadjustedCreditNoteListDto>().FromSqlRaw("getUnadjustedCreditNoteList").ToListAsync();
        }
    }
}
