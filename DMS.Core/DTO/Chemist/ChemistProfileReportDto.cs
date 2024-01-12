using DMS.Core.DTO.Discount;
using System.Collections.Generic;

namespace DMS.Core.DTO.Chemist
{
    public class ChemistProfileReportDto
    {
        public List<ChemistDetailDto> ChemistDetail { get; set; }
        public List<ChemistDiscountDto> Discount  { get; set; }
        public List<ChemistBusinessProfileDto> Business  { get; set; }
        public List<ChemistCreditProfileDto> Credit  { get; set; }
        public List<ChemistCreditDuesDto> CreditDues { get; set; }
    }
}
