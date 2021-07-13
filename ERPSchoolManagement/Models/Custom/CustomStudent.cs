using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Custom
{
    public class CustomStudent
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public int? ParentId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class CustomStudentModel
    {
        public int Sno { get; set; }
        public string StudentRegNo { get; set; }
        public string AdmNo { get; set; }
        public string StudentName { get; set; }
        public string StudentCategory { get; set; }
        public string StudentDob { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string StudentAddress { get; set; }
        public string StudentImage { get; set; }
        public DateTime? Dateofadmission { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Adharno { get; set; }
        public string SamgraId { get; set; }
        public string Incaseofemgname { get; set; }
        public string Relation { get; set; }
        public string EmgPhoneno { get; set; }
        public string EmgMobno { get; set; }
        public string EmgAddress { get; set; }
        public string FathersName { get; set; }
        public DateTime? FathersDob { get; set; }
        public string FathersMobno { get; set; }
        public string FathersProfession { get; set; }
        public string FathersDesignation { get; set; }
        public string FathersAnnualincome { get; set; }
        public string FathersEmail { get; set; }
        public string FathersResaddress { get; set; }
        public string FathersOffaddress { get; set; }
        public string MothersName { get; set; }
        public DateTime? MothersDob { get; set; }
        public string MothersMobno { get; set; }
        public string MothersProfession { get; set; }
        public string MothersDesignation { get; set; }
        public string MothersAnnualincome { get; set; }
        public string MothersEmail { get; set; }
        public string MothersResaddress { get; set; }
        public string MothersOffaddress { get; set; }
        public string BloodGroup { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string FamilyDoc { get; set; }
        public string AllergyMedDesc { get; set; }
        public string MedicalAddress { get; set; }
        public string SmsSendername { get; set; }
        public string SmsDetailemail { get; set; }
        public string SmsDetailmobno { get; set; }
        public string SmsDetailaltmobno { get; set; }
        public string StudentType { get; set; }
        public DateTime? Timeofsync { get; set; }
    }
}
