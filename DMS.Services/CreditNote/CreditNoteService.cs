using DMS.Core.Dto.User;
using DMS.Core.DTO.CreditNote;
using DMS.Core.Models.CreditNote;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repository;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.CreditNote
{
    public class CreditNoteService : ICreditNoteService
    {
        private DbContext context;
        private DbContext invContext;
        private CreditNoteRepository repo;
        private readonly CodeGenerateRepository codeRepo = null;


        public CreditNoteService(IConfiguration Config)
        {
            context = new CreditNoteContext(Config);
            repo = new CreditNoteRepository(context);

            this.invContext = new InvoiceContext(Config);
            this.codeRepo = new CodeGenerateRepository(this.invContext);

        }

        public async Task<ChemistApprovedTotalAmount> getChemistAprrovedTotalAmount(string chemistCode)
        {
            return await repo.getChemistAprrovedTotalAmount(chemistCode);
        }

        public async Task<List<CreditNoteAdjustmentPendingDto>> getCreditNoteAdjustmentPending()
        {

            return await repo.getCreditNoteAdjustmentPending();
        }

        public async Task<List<CreditNoteAdjustedMoneyDto>> getCreditNoteAdjustedMoney()
        {

            return await repo.getCreditNoteAdjustedMoney();
        }

        public async Task<List<AdjustedCreditNoteDto>> getChemistCreditNoteAdjustedMoneyDetails(string chemistCode)
        {
            return await repo.getChemistCreditNoteAdjustedMoneyDetails(chemistCode);
        }

        public async Task<List<ApprovedCreditNoteList>> getChemistCreditNoteAprrovedMoneyDetails(string depoCode, string chemistCode)
        {

            return await repo.getChemistCreditNoteAprrovedMoneyDetails(depoCode, chemistCode);
        }

        public async Task<Boolean> saveAdjustment(string ChemistCode, string InvoiceCode, decimal CreditNoteAdjustedAmount, UserBasicInfo _SESSION_USER)
        {

            CreditNoteAdjustment noteAdjustment = new CreditNoteAdjustment();
            noteAdjustment.AdjustmentCode = await this.codeRepo.getGeneratedCode("CREDIT_NOTE_ADJUSTMENT");
            noteAdjustment.ChemistCode = ChemistCode;
            noteAdjustment.InvoiceCode = InvoiceCode;
            noteAdjustment.Amount = CreditNoteAdjustedAmount;
            noteAdjustment.CreatedById = _SESSION_USER.EmployeeID;
            noteAdjustment.IsActive = true;

            List<CreditNoteAdjustmentDetailDto> CreditNotes = await repo.getChemistCreditNotePayable(ChemistCode);
            //List<CreditNoteAdjustmentDetail> adjustmentDetail = new List<CreditNoteAdjustmentDetail>();

           

            try
            {
                await this.repo.BEGIN_TRANSACTION();

                await this.repo.saveAdjustment(noteAdjustment);


                foreach (CreditNoteAdjustmentDetailDto item in CreditNotes)
                {
                    CreditNoteAdjustmentDetail detail = new CreditNoteAdjustmentDetail();
                    detail.AdjustmentCode = noteAdjustment.AdjustmentCode;
                    detail.CreditNoteCode = item.CreditNoteCode;
                    detail.Amount = item.Amount;
                    detail.IsActive = true;

                    await this.repo.saveAdjustmentDetail(detail);
                }

                await this.repo.COMMIT();
            }
            catch { await this.repo.ROLL_BACK(); }

            return true;
        }
    }
}
