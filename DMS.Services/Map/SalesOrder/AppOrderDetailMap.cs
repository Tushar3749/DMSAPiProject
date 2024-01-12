using AutoMapper;
using DMS.Core.Dto.SalesOrder;
using DMS.Core.Models.SalesInvoice;

namespace DMS.Services.Map.SalesOrder
{
    public class AppOrderDetailMap
    {
		public OrdersDetail map(AppSalesOrderDetailDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<AppSalesOrderDetailDto, OrdersDetail>();
			});

			return config.CreateMapper().Map<AppSalesOrderDetailDto, OrdersDetail>(source);
		}

	}
}
