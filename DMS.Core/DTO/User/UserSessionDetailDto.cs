using System;

namespace DMS.Core.Dto.User
{
    public class UserSessionDetailDto
    {
		public Nullable<int> ID { get; set; }
		public string EmployeeID { get; set; }
		public string EmployeeName { get; set; }
		public Nullable<int> DesignationID { get; set; }
		public Nullable<int> DepartmentID { get; set; }

		public string ProfileImagename { get; set; }
		public string SignatureFilename { get; set; }
	}
}
