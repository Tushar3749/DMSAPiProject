using DMS.Core.DTO.CreditNote;
using DMS.Core.Models.CreditNote;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class CreditNoteRepository:Repository
    {
        private DbContext context = null;

        private GenericRepository<CreditNoteAdjustment> adjustment = null;
        private GenericRepository<CreditNoteAdjustmentDetail> adjustmentDetail = null;


        public CreditNoteRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.adjustment = new GenericRepository<CreditNoteAdjustment>(context);
            this.adjustmentDetail = new GenericRepository<CreditNoteAdjustmentDetail>(context);
        }

        public async Task<ChemistApprovedTotalAmount> getChemistAprrovedTotalAmount(string chemistCode)
        {

            var result = await this.context.Set<ChemistApprovedTotalAmount>().FromSqlRaw("exec getChemistCreditNotePayable @ChemistCode", new SqlParameter("@ChemistCode", chemistCode)).ToListAsync();
            //result.FirstOrDefault().Amount = 100;
            return result.FirstOrDefault();
        }


        public async Task<List<CreditNoteAdjustmentDetailDto>> getChemistCreditNotePayable(string ChemistCode)
        {

            var result = await this.context.Set<CreditNoteAdjustmentDetailDto>().FromSqlRaw("exec getChemistCreditNotePayable @ChemistCode, 1",
                    new SqlParameter("@ChemistCode", ChemistCode)
                    ).ToListAsync();
            return result;
        }



        public async Task<List<CreditNoteAdjustmentPendingDto>> getCreditNoteAdjustmentPending()
        {
            var result = await this.context.Set<CreditNoteAdjustmentPendingDto>().FromSqlRaw("exec getCreditNoteAdjustmentPending").ToListAsync();
            return result;
        }

        public async Task<List<CreditNoteAdjustedMoneyDto>> getCreditNoteAdjustedMoney()
        {
            var result = await this.context.Set<CreditNoteAdjustedMoneyDto>().FromSqlRaw("exec getCreditNoteAdjustedMoney").ToListAsync();
            return result;
        }



        public async Task<List<AdjustedCreditNoteDto>> getChemistCreditNoteAdjustedMoneyDetails(string chemistCode)
        {

            var result = await this.context.Set<AdjustedCreditNoteDto>().FromSqlRaw("exec getChemistCreditNoteAdjustedMoneyDetails @ChemistId", new SqlParameter("@ChemistId", chemistCode)).ToListAsync();
            return result;
        }

        public async Task<List<ApprovedCreditNoteList>> getChemistCreditNoteAprrovedMoneyDetails(string depoCode, string chemistCode)
        {

            var result = await this.context.Set<ApprovedCreditNoteList>().FromSqlRaw("exec getChemistCreditNoteAprrovedMoneyDetails @DepoCode,@ChemistId",
                new SqlParameter("@DepoCode", depoCode), new SqlParameter("@ChemistId", chemistCode)).ToListAsync();
            return result;
        }


        // SAVE
        public async Task<CreditNoteAdjustment> saveAdjustment(CreditNoteAdjustment Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<CreditNoteAdjustment>(this.context).Insert(Entity);
        }

        // SAVE
        public async Task<CreditNoteAdjustmentDetail> saveAdjustmentDetail(CreditNoteAdjustmentDetail Entity)
        {
            Entity.IsActive = true;
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<CreditNoteAdjustmentDetail>(this.context).Insert(Entity);
        }


    }
}
