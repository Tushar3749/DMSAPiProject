using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.DayOperation
{

	[Keyless]
    public class DepotDayOperationStatusDto
    {
		public string? ReportDate { get; set; }

		public Nullable<Boolean> IsDayOpened { get; set; }
		public Nullable<Boolean> IsDayClosed { get; set; }
		public string? DayNextOperation { get; set; }
		public Nullable<DateTime> DayClosedAt { get; set; }
		public Nullable<DateTime> DayOpenedAt { get; set; }

		public string? DayOpenedBy { get; set; }
		public string? DayClosedBy { get; set; }
	}
}
