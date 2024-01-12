using AutoMapper;
using DMS.Core.DTO.SummaryReturn;

namespace DMS.Services.Map.SummaryReturn
{
    public class AllocationInvoiceForSummaryMasterMap
    {

		public AllocationInvoiceForSummaryMasterDto map(AllocationInvoiceForSummaryDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<AllocationInvoiceForSummaryDto, AllocationInvoiceForSummaryMasterDto>();
			});

			return config.CreateMapper().Map<AllocationInvoiceForSummaryDto, AllocationInvoiceForSummaryMasterDto>(source);
		}

	}
}
