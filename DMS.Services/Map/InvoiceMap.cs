using AutoMapper;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SalesInvoice;

namespace DMS.Services.Map
{
    public class InvoiceMap
    {
		public Invoice map(InvoiceMasterDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<InvoiceMasterDto,Invoice>();
			});

			return config.CreateMapper().Map<InvoiceMasterDto, Invoice>(source);
		}

		public InvoiceDetail mapDetail(InvoiceDetailNewDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<InvoiceDetailNewDto, InvoiceDetail>()
				.ForMember(d => d.Amount, o => o.MapFrom(s => s.ProductAmount))
				.ForMember(d => d.TotalAmountDiscount, o => o.MapFrom(s => s.AmountDiscount))
				.ForMember(d => d.TotalProductDiscount, o => o.MapFrom(s => s.ProductDiscount));
			});

			return config.CreateMapper().Map<InvoiceDetailNewDto, InvoiceDetail>(source);
		}
	}
}
