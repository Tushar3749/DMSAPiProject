using AutoMapper;
using DMS.Core.DTO.Chemist;
using DMS.Core.Models.SalesMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.Chemist
{
    public class ChemistMap
    {
		// MAPPING 
		public DMS.Core.Models.SalesMaster.Chemist map(ChemistDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ChemistDto, DMS.Core.Models.SalesMaster.Chemist>();
			});

			return config.CreateMapper().Map<ChemistDto, DMS.Core.Models.SalesMaster.Chemist>(source);
		}
	}
}
