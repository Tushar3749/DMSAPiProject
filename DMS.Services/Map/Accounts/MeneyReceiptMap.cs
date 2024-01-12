using AutoMapper;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.Models.Accounts;
using DMS.Core.Models.SummaryInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.Accounts
{
    public class MeneyReceiptMap
    {
		public SummaryCollectionDetail mapCollectionDetail(SummaryCollectionDetailNew source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<SummaryCollectionDetailNew, SummaryCollectionDetail>();
			});

			return config.CreateMapper().Map<SummaryCollectionDetailNew, SummaryCollectionDetail>(source);
		}
	}
}
