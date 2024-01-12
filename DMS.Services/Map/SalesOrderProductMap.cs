using AutoMapper;
using DMS.Core.DTO.Orders;
using DMS.Core.Models.SalesInvoice;

namespace DMS.Services.Map
{
    public class SalesOrderProductMap
    {
		public OrdersDetail map(OrdersDetailDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<OrdersDetailDto, OrdersDetail>()
				.ForMember(dest => dest.Quantity, option => option.MapFrom(src => src.Quantity));
			});

			return config.CreateMapper().Map<OrdersDetailDto, OrdersDetail>(source);
		}


	}
}
