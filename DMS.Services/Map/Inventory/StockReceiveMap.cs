using AutoMapper;
using DMS.Core.DTO.Inventory;
using DMS.Core.Models.Inventory;

namespace DMS.Services.Map.Inventory
{
    public class StockReceiveMap
    {
        public StockReceive map(StockReceiveDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StockReceiveDTO, StockReceive>();
            });

            return config.CreateMapper().Map<StockReceiveDTO, StockReceive>(source);
        }

        public StockReceive mapChallanReceive(StockReceivePendingChallanDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StockReceivePendingChallanDto, StockReceive>();
            });

            return config.CreateMapper().Map<StockReceivePendingChallanDto, StockReceive>(source);
        }

        public StockReceiveDetail mapChallanReceiveDetail(StockReceiveDetailPendingChallanDto source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StockReceiveDetailPendingChallanDto, StockReceiveDetail>();
            });

            return config.CreateMapper().Map<StockReceiveDetailPendingChallanDto, StockReceiveDetail>(source);
        }
    }
}
