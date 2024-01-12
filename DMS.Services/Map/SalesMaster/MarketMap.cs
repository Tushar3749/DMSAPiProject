using AutoMapper;
using DMS.Core.DTO.SalesMaster;
using DMS.Core.Models.SalesMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.SalesMaster
{
    public class MarketMap
    {
		public Market map(MarketDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<MarketDto, Market>();
			});

			return config.CreateMapper().Map<MarketDto, Market>(source);
		}
	}
}
