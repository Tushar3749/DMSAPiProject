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
using DMS.Core.Models.SummaryInvoice;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.Core.DTO.SummaryReturn;

namespace DMS.Data.Repository
{
   public class InvoiceAllocationRepository : Repository
    {

        private GenericRepository<InvoiceAllocation> invallo = null;
        private DbContext context = null;
        public InvoiceAllocationRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.invallo = new GenericRepository<InvoiceAllocation>(context);
        }

        //Get All
        public async Task<List<InvoiceAllocationDTO>> getInvoiceAllocation()
        {
            var result = await new GenericRepository<InvoiceAllocation>(this.context).Find(i => i.IsActive == true);
            return result.Select(x => new InvoiceAllocationDTO
            {
                ID = x.Id,
                AllocationCode = x.AllocationCode,
                AllocationDate = x.AllocationDate,
                DepotCode = x.DepotCode,
                ReturnDate = x.ReturnDate
            }).ToList();
        }


        // SAVE
        public async Task<InvoiceAllocation> saveInvoiceAllocation(InvoiceAllocation Entity)
        {
            try
            {
                Entity.IsActive = true;
                Entity.CreatedOn = DateTime.Now;
                var result = await new GenericRepository<InvoiceAllocation>(this.context).Insert(Entity);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        // UPDATE
        public async Task<InvoiceAllocation>  updateInvoiceAllocation( InvoiceAllocation Entity)
        {
            Entity.UpdatedOn = DateTime.Now;
            try
            {
                var result = await new GenericRepository<InvoiceAllocation>(this.context).Update(Entity, I => I.AllocationCode == Entity.AllocationCode);

                return result;

            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<InvoiceAllocationDetail> updateInvoiceAllocationDetail(String InvoiceCode, InvoiceAllocationDetail Entity)
        {
            Entity.UpdatedOn = DateTime.Now;

            var result = await new GenericRepository<InvoiceAllocationDetail>(this.context).Update(Entity, I => I.InvoiceCode == InvoiceCode);

            return result;
        }

        // Find One
        public async Task<InvoiceAllocation> findOneAllocationInvoiceByallocationCode(string allocationCode)
        {
            return await new GenericRepository<InvoiceAllocation>(this.context).FindOne(i => i.IsActive == true && i.AllocationCode == allocationCode);
        }

        //SP
        public async Task<List<InvoiceAllocation>> getAllocationInvoiceReportList()
        {
            return await new GenericRepository<InvoiceAllocation>(context).FindUsingSPAsync("getInvoiceAllocation", null);
        }
        public async Task<List<PendingInvoiceAllocationDTO>> getInvoiceForNewAllocationList()
        {
            return await new GenericRepository<PendingInvoiceAllocationDTO>(context).FindUsingSPAsync("getInvoiceForNewAllocation", null);
        }
        public async Task<List<PendingAllocationDispatchDTO>> getPendingDispatchInvoiceAllocationList()
        {
            return await new GenericRepository<PendingAllocationDispatchDTO>(context).FindUsingSPAsync("getPendingDispatchInvoiceAllocationList", null);
        }
        public async Task<List<InvoiceAllocationDispatchMasterDTO>> getInvoiceandChemistInfoByAllocationCode(string AllocationCode)
        {
            SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@AllocationCode", AllocationCode) };

            return await new GenericRepository<InvoiceAllocationDispatchMasterDTO>(context).FindUsingSPAsync("exec getInvoiceandChemistInfoByAllocationCode @AllocationCode", sqlParams);
        }
        public bool findallocationInSummary(string AllocationCode)
        {
            bool res = false;
            try
            {
                Task<Summary> summary = new GenericRepository<Summary>(this.context).FindOne(i => i.IsActive == true && i.AllocationCode == AllocationCode);
                if (summary.Result != null)
                {
                    res = true;
                }
                return res;
            }
            catch (Exception e)
            {
                return false;
            }
      

        }

        public async Task<List<DAListDTO>> getDAListByDepot(string ModuleFor = "0")
        {
            return await this.context.Set<DAListDTO>().FromSqlRaw("getDAList @ForModule", new SqlParameter("@ForModule", ModuleFor)).ToListAsync();
        }

        public async Task<List<InvoiceAllocationDispatchDTO>> getAllocationDetailsByAllocationCode(string AllocationCode)
        {
            return await this.context.Set<InvoiceAllocationDispatchDTO>().FromSqlRaw("exec getAllocationDetailsByAllocationCode @AllocationCode", new SqlParameter("@AllocationCode", AllocationCode)).ToListAsync();
        }
        public async Task<List<ProductReturnReportDTO>> getSummaryAndAllocationByDA(string DACode, DateTime startdate, DateTime enddate)
        {
            return await this.context.Set<ProductReturnReportDTO>().FromSqlRaw("exec getSummaryAndAllocationByDA @DACode, @StartDate, @EndDate", new SqlParameter("@DACode", DACode), new SqlParameter("@StartDate", startdate), new SqlParameter("@EndDate", enddate)).ToListAsync();
        }
        public async Task<List<ProductReturnReportDTO>> getSummaryAndAllocationReturnByDA(string DACode, DateTime startdate, DateTime enddate)
        {
            try
            {
                var RES = await this.context.Set<ProductReturnReportDTO>().FromSqlRaw("exec getSummaryAndAllocationReturnByDA @DACode, @StartDate, @EndDate", new SqlParameter("@DACode", DACode)
                 , new SqlParameter("@StartDate", startdate), new SqlParameter("@EndDate", enddate)).ToListAsync();
                return RES;
            }
            catch(Exception E)
            {
                return null;
            }
       
        }
        // Find
        public async Task<List<InvoiceAllocationDTO>> getInvoiceAllocationByallocationCode(string allocationCode)
        {
            var result = await new GenericRepository<InvoiceAllocation>(this.context).Find(i => i.IsActive == true && i.AllocationCode == allocationCode);

            return result.Select(x => new InvoiceAllocationDTO
            {
                ID = x.Id,
                AllocationCode = x.AllocationCode,
                AllocationDate = x.AllocationDate,
                DepotCode = x.DepotCode,
                ReturnDate = x.ReturnDate
            }).ToList();
        }

        public async Task<List<InvoiceAllocation>> getInvoiceAllocationByDACode(string DAcode, DateTime startdate, DateTime enddate)
        {
            try
            {
                var result = await new GenericRepository<InvoiceAllocation>(this.context).Find(i => i.IsActive == true && i.Dacode == DAcode &&( i.AllocationDate >= startdate && i.AllocationDate < enddate));
                return result;
            }
            catch(Exception e)
            {
                return null;
            }
          
        }
        public async Task<List<InvoiceAllocation>> getInvoiceAllocationByDate(DateTime startdate, DateTime enddate)
        {
            try
            {
                var result = await new GenericRepository<InvoiceAllocation>(this.context).Find(i => i.IsActive == true && (i.AllocationDate >= startdate && i.AllocationDate < enddate));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<InvoiceAllocation>> getSummaryPendingInvoiceAllocationByDA(string DACode)
        {
            return await this.context.Set<InvoiceAllocation>().FromSqlRaw("exec getSummaryPendingInvoiceAllocationByDA @DACode", new SqlParameter("@DACode", DACode)).ToListAsync();
        }
        public async Task<List<AllocationInvoiceStatementDTO>> getAllocationInvoiceStatement(string DACode,DateTime Fromdate,DateTime Enddate,string status)
        {
            return await this.context.Set<AllocationInvoiceStatementDTO>().FromSqlRaw("exec getAllocationInvoiceStatement  @FromDate,@ToDate,@DACode,@status",
                new SqlParameter("@FromDate", Fromdate), 
                new SqlParameter("@ToDate", Enddate), 
                new SqlParameter("@DACode", DACode), 
                new SqlParameter("@status", status)).ToListAsync();
        }
        public async Task<List<SummaryStatementDTO>> getSummaryStatement( DateTime Fromdate, DateTime Enddate, string DACode)
        {
            if ((String.IsNullOrEmpty(DACode) || DACode == "Select DA"))
                return await this.context.Set<SummaryStatementDTO>().FromSqlRaw("exec getSummaryStatement @FromDate,@ToDate", new SqlParameter("@FromDate", Fromdate), new SqlParameter("@ToDate", Enddate)).ToListAsync();
            else
                return await this.context.Set<SummaryStatementDTO>().FromSqlRaw("exec getSummaryStatement  @FromDate,@ToDate,@DACode", new SqlParameter("@FromDate", Fromdate), new SqlParameter("@ToDate", Enddate), new SqlParameter("@DACode", DACode)).ToListAsync();
        }
        public async Task <List<InvoiceNewDTO>> UpdateInvoiceAllocationAndInvoice(string InvoiceCode)
        {
            try
            {
                var result = await new GenericRepository<InvoiceAllocationDetail>(this.context).Find(i => i.IsActive == true && i.InvoiceCode == InvoiceCode);
                if (result.Count > 0)
                {
                    var data = await this.context.Set<InvoiceAllocationDetailNewDTO>().FromSqlRaw("exec updateInvoiceAllocationDetail @InvoiceCode", new SqlParameter("@InvoiceCode", InvoiceCode)).ToListAsync();
                }
                return await this.context.Set<InvoiceNewDTO>().FromSqlRaw("exec updateInvoice @InvoiceCode", new SqlParameter("@InvoiceCode", InvoiceCode)).ToListAsync();
            }         
            catch(Exception e)
            {return null;}
        }


        public async Task<InvoiceAllocationDetail> getAllocatedActiveInvoice(string InvoiceCode)
        {
            return await new GenericRepository<InvoiceAllocationDetail>(this.context).FindOne(I => I.InvoiceCode == InvoiceCode && I.IsActive == true);
        }



    }
}
