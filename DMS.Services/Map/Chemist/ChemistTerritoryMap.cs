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
    public class ChemistTerritoryMap
    {
		// MAPPING 
		public ChemistTerritory map(ChemistTerritoryDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ChemistTerritoryDto, ChemistTerritory>();
			});

			return config.CreateMapper().Map<ChemistTerritoryDto, ChemistTerritory>(source);
		}
	}
}
