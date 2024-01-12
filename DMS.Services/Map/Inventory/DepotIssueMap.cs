using AutoMapper;
using DMS.Core.DTO.Inventory;
using DMS.Core.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.Inventory
{
    public class DepotIssueMap
    {
        public StockIssue map(DepotIssueDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepotIssueDto, StockIssue>();
            });

            return config.CreateMapper().Map<DepotIssueDto, StockIssue>(source);
        }

        public StockIssueDetail mapDetail(DepotIssueDetailDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepotIssueDetailDto, StockIssueDetail>();
            });

            return config.CreateMapper().Map<DepotIssueDetailDto, StockIssueDetail>(source);
        }
    }
}
