using DMS.Core.DTO.CreditNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface ICreditNoteService
    {
        Task<List<CreditNoteAdjustmentPendingDto>> getCreditNoteAdjustmentPending();
        Task<List<CreditNoteAdjustedMoneyDto>> getCreditNoteAdjustedMoney();
        Task<List<ApprovedCreditNoteList>> getChemistCreditNoteAprrovedMoneyDetails(string depoCode, string chemistCode);
        Task<List<AdjustedCreditNoteDto>> getChemistCreditNoteAdjustedMoneyDetails(string chemistCode);

        Task<ChemistApprovedTotalAmount> getChemistAprrovedTotalAmount(string chemistCode);
    }
}
