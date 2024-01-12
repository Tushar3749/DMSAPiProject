using DMS.Core.Dto.SalesOrder;
using System.Collections.Generic;

namespace DMS.Core.DTO.SalesOrder.AppOrder
{
    public class AppOrderReceiveDto
    {
        public List<AppSalesOrderDto> Orders { get; set; }
        public List<AppSalesOrderDetailDto> OrderDetails { get; set; }
    }
}
