using Microsoft.EntityFrameworkCore;

namespace DMS.Core.DTO.CreditNote
{

    [Keyless]
    public class CreditNoteAdjustmentDetailDto
    {
        public string CreditNoteCode { get; set; }
        public decimal Amount { get; set; }
    }
}
