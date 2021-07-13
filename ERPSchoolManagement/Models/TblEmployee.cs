using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class TblEmployee
    {
        public int Sno { get; set; }
        public string TeacherRegId { get; set; }
        public string StaffType { get; set; }
        public string EmpId { get; set; }
        public string TeacherName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherImage { get; set; }
        public DateTime? TeacherDob { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string AlternateMobno { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Grade { get; set; }
        public string JobTitle { get; set; }
        public bool? IsClassTeacher { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string DateOfAnniversary { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public bool? IsActive { get; set; }
    }
}
