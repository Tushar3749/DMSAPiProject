using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO.User
{

	[Keyless]
    public class DMSUserPrivilegedMenuDto
	{
		public Nullable<int> MenuID { get; set; }

		public Nullable<int> ModuleID { get; set; }
		public string? MenuName { get; set; }
		public string? Route { get; set; }

		public int? MenuNumber { get; set; }
		public Nullable<Boolean> IsActive { get; set; }
		public Nullable<Boolean> HasView { get; set; }

		public Nullable<Boolean> HasInsert { get; set; }
		public Nullable<Boolean> HasUpdate { get; set; }
		public Nullable<Boolean> HasDelete { get; set; }
		public Nullable<Boolean> HasPrint { get; set; }
		public Nullable<Boolean> HasFullAccess { get; set; }

		public Nullable<Boolean> HasApprove { get; set; }
	}

}
