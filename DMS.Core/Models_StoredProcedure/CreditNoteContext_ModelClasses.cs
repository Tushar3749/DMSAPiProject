using DMS.Core.DTO.CreditNote;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.Models_StoredProcedure
{
    public class CreditNoteContext_ModelClasses: DbContext
    {
        public CreditNoteContext_ModelClasses() : base()
        {

        }

        protected virtual DbSet<CreditNoteAdjustmentPendingDto> CreditNoteAdjustmentPendingDto { get; set; }
        protected virtual DbSet<CreditNoteAdjustedMoneyDto> CreditNoteAdjustedMoneyDto { get; set; }
        protected virtual DbSet<ApprovedCreditNoteList> ApprovedCreditNotes { get; set; }
        protected virtual DbSet<ChemistApprovedTotalAmount> ChemistApprovedTotalAmounts { get; set; }
        protected virtual DbSet<CreditNoteAdjustmentDetailDto> CreditNoteAdjustmentDetailDto { get; set; }
        protected virtual DbSet<AdjustedCreditNoteDto> AdjustedCreditNoteDto { get; set; }

    }
    
}
