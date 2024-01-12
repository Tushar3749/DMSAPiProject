using System.Collections.Generic;

namespace DMS.Core.DTO.Discount
{
    public class DiscountDto
    {

        public DiscountReportDto Discount { get; set; }
        public List<DiscountDetailDto> DiscountDetails { get; set; }
    }
}
