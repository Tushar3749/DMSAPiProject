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
    public class ChemistCreditMap
    {
		// MAPPING 
		public ChemistCredit map(ChemistCreditDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<ChemistCreditDto, ChemistCredit>();
			});

			return config.CreateMapper().Map<ChemistCreditDto, ChemistCredit>(source);
		}
	}
}
