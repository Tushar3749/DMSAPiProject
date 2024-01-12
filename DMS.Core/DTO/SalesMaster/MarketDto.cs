using System;

namespace DMS.Core.DTO.SalesMaster
{
    public class MarketDto
	{
		public Nullable<int> ID { get; set; }

		public string MarketCode { get; set; }
		public string MarketName { get; set; }
		public Nullable<int> UpazilaID { get; set; }
		public Nullable<int> ThanaID { get; set; }
		public string CreatedByID { get; set; }
	}
}
