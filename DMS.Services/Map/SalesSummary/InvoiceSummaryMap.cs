using AutoMapper;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.SummaryInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.SalesSummary
{
    public class InvoiceSummaryMap
    {
		public SummaryInvoice map(AllocationInvoiceForSummaryMasterDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<AllocationInvoiceForSummaryMasterDto, SummaryInvoice>();
				cfg.CreateMap<AllocationInvoiceForSummaryMasterDto, SummaryInvoice>().ForMember(src => src.ReturnType, opt => opt.MapFrom(src => src.ReturnStatus));
			});

			return config.CreateMapper().Map<AllocationInvoiceForSummaryMasterDto, SummaryInvoice>(source);
		}

		public SummaryInvoiceDetail mapDetail(SummaryInvoiceDetailDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>();

				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.Tp, opt => opt.MapFrom(src => src.TP.GetValueOrDefault()));
				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.Sps, opt => opt.MapFrom(src => src.SPS.GetValueOrDefault()));

				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.TotalTp, opt => opt.MapFrom(src => src.TotalTP.GetValueOrDefault()));
				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.TotalVat, opt => opt.MapFrom(src => src.TotalVAT.GetValueOrDefault()));
				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.TotalAmountDiscount, opt => opt.MapFrom(src => src.AmountDiscount.GetValueOrDefault()));
				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.TotalProductDiscount, opt => opt.MapFrom(src => src.ProductDiscount.GetValueOrDefault()));

				cfg.CreateMap<SummaryInvoiceDetailDto, SummaryInvoiceDetail>().ForMember(dest => dest.IsInvoiceDiscountApplicable, opt => opt.MapFrom(src => src.IsInvoiceAmountDiscountApplicable.GetValueOrDefault()));
			});

			return config.CreateMapper().Map<SummaryInvoiceDetailDto, SummaryInvoiceDetail>(source);
		}
	}
}
