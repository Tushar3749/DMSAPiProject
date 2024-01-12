using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.Dto.User
{
	[Keyless]
    public class UserBasicInfo
    {
		public Nullable<int> ID { get; set; }

		public string EmployeeID { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<int> DesignationID { get; set; }
		public string DesignationName { get; set; }
		public Nullable<int> DepartmentID { get; set; }

		public string DepartmentName { get; set; }
		public string ProfileImagename { get; set; }
		public string SignatureFilename { get; set; }
		public string LocationID { get; set; }
		public string DepotCode { get; set; }
		public string Mobile { get; set; }

	}
}
