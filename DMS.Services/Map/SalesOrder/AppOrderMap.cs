using AutoMapper;
using DMS.Core.Dto.SalesOrder;
using DMS.Core.Models.SalesInvoice;

namespace DMS.Services.Map.SalesOrder
{
	public class AppOrderMap
    {
		public Order map(AppSalesOrderDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<AppSalesOrderDto, Order>();
			});

			return config.CreateMapper().Map<AppSalesOrderDto, Order>(source);
		}


	}
}
