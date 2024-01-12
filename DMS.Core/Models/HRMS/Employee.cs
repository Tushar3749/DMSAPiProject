using System;
using System.Collections.Generic;

#nullable disable

namespace DMS.Core.Models.HRMS
{
    public partial class Employee
    {
        public string EmployeeId { get; set; }
        public int? CardNo { get; set; }
        public string Salutation { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string NickName { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime Dob { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Sex { get; set; }
        public string MaritalStatus { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NationalIdno { get; set; }
        public string EpersonName { get; set; }
        public string EpersonAddress { get; set; }
        public string EpersonTelephone { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmployeeType { get; set; }
        public string CompanyId { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string Zone { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string Territory { get; set; }
        public DateTime Doj { get; set; }
        public DateTime? Dos { get; set; }
        public string JoiningPosition { get; set; }
        public string JoiningGrade { get; set; }
        public string AcademicAward { get; set; }
        public string DrivingLicence { get; set; }
        public string Passport { get; set; }
        public string VisitCountry { get; set; }
        public string ExtraActivities { get; set; }
        public string MajorIllness { get; set; }
        public string SuperVisorId { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string ConfirmationStatus { get; set; }
        public bool Certification { get; set; }
        public DateTime? LastAppDate { get; set; }
        public string LastAppType { get; set; }
        public string CostCenter { get; set; }
        public string Remarks { get; set; }
        public string LeaveRuleId { get; set; }
        public string MachineNameIp { get; set; }
        public bool Transfered { get; set; }
        public bool Hotransfered { get; set; }
        public string Addedby { get; set; }
        public DateTime DateAdded { get; set; }
        public string Updatedby { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? OfficeLocationId { get; set; }
    }
}
