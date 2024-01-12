using AutoMapper;
using DMS.Core.DTO.Orders;
using DMS.Core.DTO.SalesInvoice;

namespace DMS.Services.Map.SalesInvoice
{
    public class OrderDetailToInvoiceDetailMap
    {
		public InvoiceDetailNewDto map(InvoicePendingOrderDetail source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<InvoicePendingOrderDetail, InvoiceDetailNewDto>();
			});

			return config.CreateMapper().Map<InvoicePendingOrderDetail, InvoiceDetailNewDto>(source);
		}

	}
}
