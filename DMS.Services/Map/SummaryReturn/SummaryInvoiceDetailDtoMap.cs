using AutoMapper;
using DMS.Core.DTO.SummaryReturn;

namespace DMS.Services.Map.SummaryReturn
{
    public class SummaryInvoiceDetailDtoMap
    {
		public SummaryInvoiceDetailDto map(SummaryInvoiceDetailNewDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<SummaryInvoiceDetailNewDto, SummaryInvoiceDetailDto>();
			});

			return config.CreateMapper().Map<SummaryInvoiceDetailNewDto, SummaryInvoiceDetailDto>(source);
		}
	}
}
