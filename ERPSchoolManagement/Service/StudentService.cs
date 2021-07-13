using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Service
{
    public class StudentService : IStudent
    {

        readonly SchoolManagementERPDBContext _context;

        public StudentService(SchoolManagementERPDBContext context)
        {
            _context = context;
        }
        #region Student
        public async Task<bool> AddStudent(CustomStudentModel StudentRequest)
        {
            var _student = GetStudent(StudentRequest);
            _context.TblStudent.Add(_student);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomStudentModel> GetStudent(int StudentId)
        {
            var _student = await _context.TblStudent.Where(x => x.Sno == StudentId).FirstOrDefaultAsync();
            var customStudent = GetStudent(_student);
            return customStudent;
        }

        public async Task<IEnumerable<CustomStudentModel>> GetStudentList()
        {
            var students = _context.TblStudent.AsEnumerable();
            List<CustomStudentModel> customStudent = new List<CustomStudentModel>();
            foreach (var student in students)
            {
                customStudent.Add(GetStudent(student));
            }
            return customStudent.AsEnumerable();
        }

        public async Task<bool> UpdateStudent(CustomStudentModel user)
        {
            var _student = await _context.TblStudent.Where(x => x.Sno == user.Sno).FirstOrDefaultAsync();
            if (_student != null)
            {
                _student.Sno = user.Sno;
                _student.City = user.City;
                _student.Adharno = user.Adharno;
                _student.AdmNo = user.AdmNo;
                _student.AllergyMedDesc = user.AllergyMedDesc;
                _student.EmgAddress = user.EmgAddress;
                _student.FathersAnnualincome = user.FathersAnnualincome;
                _student.Incaseofemgname = user.Incaseofemgname;
                _student.FathersOffaddress = user.FathersOffaddress;
                _student.Weight = user.Weight;
                _student.BloodGroup = user.BloodGroup;
                _student.Caste = user.Caste;
                _student.Class = user.Class;
                _student.Dateofadmission = user.Dateofadmission;
                _student.EmgMobno = user.EmgMobno;
                _student.EmgPhoneno = user.EmgPhoneno;
                _student.FathersEmail = user.FathersEmail;
                _student.MothersEmail = user.MothersEmail;
                _student.MedicalAddress = user.MedicalAddress;
                _student.MothersAnnualincome = user.MothersAnnualincome;
                _student.MothersDesignation = user.MothersDesignation;
                _student.MothersDob = user.MothersDob;
                _student.MothersMobno = user.MothersMobno;
                _student.MothersName = user.MothersName;
                _student.MothersOffaddress = user.MothersOffaddress;
                _student.MothersProfession = user.MothersProfession;
                _student.MothersResaddress = user.MothersResaddress;
                _student.FathersMobno = user.FathersMobno;
                _student.FamilyDoc = user.FamilyDoc;
                _student.FathersDesignation = user.FathersDesignation;
                _student.FathersDob = user.FathersDob;
                _student.FathersName = user.FathersName;
                _student.FathersProfession = user.FathersProfession;
                _student.FathersResaddress = user.FathersResaddress;
                _student.Gender = user.Gender;
                _student.Height = user.Height;
                _student.Nationality = user.Nationality;
                _student.Relation = user.Relation;
                _student.Religion = user.Religion;
                _student.StudentRegNo = user.StudentRegNo;
                _student.SamgraId = user.SamgraId;
                _student.Section = user.Section;
                _student.SmsDetailaltmobno = user.SmsDetailaltmobno;
                _student.SmsDetailemail = user.SmsDetailemail;
                _student.SmsDetailmobno = user.SmsDetailmobno;
                _student.SmsSendername = user.SmsSendername;
                _student.State = user.State;
                _student.StudentAddress = user.StudentAddress;
                _student.StudentCategory = user.StudentCategory;
                _student.StudentDob = user.StudentDob;
                _student.StudentImage = user.StudentImage;
                _student.StudentName = user.StudentName;
                _student.StudentType = user.StudentType;
                _student.Timeofsync = user.Timeofsync;
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Parent

        public async Task<bool> AddParent(CustomParent ParentRequest)
        {
            var _student = GetParent(ParentRequest);
            _context.Parent.Add(_student);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomParent> GetParent(int ParentId)
        {
            var _parent = await _context.Parent.Where(x => x.Id == ParentId).FirstOrDefaultAsync();
            var customParent = GetParent(_parent);
            return customParent;
        }

        public async Task<IEnumerable<CustomParent>> GetParentList()
        {
            var parents = _context.Parent.AsEnumerable();
            List<CustomParent> customParent = new List<CustomParent>();
            foreach (var parent in parents)
            {
                customParent.Add(GetParent(parent));
            }
            return customParent.AsEnumerable();
        }

        public async Task<bool> UpdateParent(CustomParent Parent)
        {
            var _parent = await _context.Parent.Where(x => x.Id == Parent.Id).FirstOrDefaultAsync();
            if (_parent != null)
            {
                _parent.CreatedDate = Parent.CreatedDate;
                _parent.DateOfJoin = Parent.DateOfJoin;
                _parent.Dob = Parent.Dob;
                _parent.Email = Parent.Email;
                _parent.FirstName = Parent.FirstName;
                _parent.LastLoginDate = Parent.LastLoginDate;
                _parent.LastName = Parent.LastName;
                _parent.MobileNo = Parent.MobileNo;
                _parent.Password = Parent.Password;
                _parent.PhoneNo = Parent.PhoneNo;
                _parent.Status = Parent.Status;                
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Private Functions
        TblStudent GetStudent(CustomStudentModel user)
        {
            TblStudent student = new TblStudent()
            {
                Sno = user.Sno,
                City = user.City,
                Adharno = user.Adharno,
                AdmNo = user.AdmNo,
                AllergyMedDesc = user.AllergyMedDesc,
                EmgAddress = user.EmgAddress,
                FathersAnnualincome = user.FathersAnnualincome,
                Incaseofemgname = user.Incaseofemgname,
                FathersOffaddress = user.FathersOffaddress,
                Weight = user.Weight,
                BloodGroup = user.BloodGroup,
                Caste = user.Caste,
                Class = user.Class,
                Dateofadmission = user.Dateofadmission,
                EmgMobno = user.EmgMobno,
                EmgPhoneno = user.EmgPhoneno,
                FathersEmail = user.FathersEmail,
                MothersEmail = user.MothersEmail,
                MedicalAddress = user.MedicalAddress,
                MothersAnnualincome = user.MothersAnnualincome,
                MothersDesignation = user.MothersDesignation,
                MothersDob = user.MothersDob,
                MothersMobno = user.MothersMobno,
                MothersName = user.MothersName,
                MothersOffaddress = user.MothersOffaddress,
                MothersProfession = user.MothersProfession,
                MothersResaddress = user.MothersResaddress,
                FathersMobno = user.FathersMobno,
                FamilyDoc = user.FamilyDoc,
                FathersDesignation = user.FathersDesignation,
                FathersDob = user.FathersDob,
                FathersName = user.FathersName,
                FathersProfession = user.FathersProfession,
                FathersResaddress = user.FathersResaddress,
                Gender = user.Gender,
                Height = user.Height,
                Nationality = user.Nationality,
                Relation = user.Relation,
                Religion = user.Religion,
                StudentRegNo = user.StudentRegNo,
                SamgraId = user.SamgraId,
                Section = user.Section,
                SmsDetailaltmobno = user.SmsDetailaltmobno,
                SmsDetailemail = user.SmsDetailemail,
                SmsDetailmobno = user.SmsDetailmobno,
                SmsSendername = user.SmsSendername,
                State = user.State,
                StudentAddress = user.StudentAddress,
                StudentCategory = user.StudentCategory,
                StudentDob = user.StudentDob,
                StudentImage = user.StudentImage,
                StudentName = user.StudentName,
                StudentType = user.StudentType,
                Timeofsync = user.Timeofsync
            };

            return student;
        }

        CustomStudentModel GetStudent(TblStudent user)
        {
            CustomStudentModel customStudent = new CustomStudentModel()
            {
                Sno = user.Sno,
                City = user.City,
                Adharno = user.Adharno,
                AdmNo = user.AdmNo,
                AllergyMedDesc = user.AllergyMedDesc,
                EmgAddress = user.EmgAddress,
                FathersAnnualincome = user.FathersAnnualincome,
                Incaseofemgname = user.Incaseofemgname,
                FathersOffaddress = user.FathersOffaddress,
                Weight = user.Weight,
                BloodGroup = user.BloodGroup,
                Caste = user.Caste,
                Class = user.Class,
                Dateofadmission = user.Dateofadmission,
                EmgMobno = user.EmgMobno,
                EmgPhoneno = user.EmgPhoneno,
                FathersEmail = user.FathersEmail,
                MothersEmail = user.MothersEmail,
                MedicalAddress = user.MedicalAddress,
                MothersAnnualincome = user.MothersAnnualincome,
                MothersDesignation = user.MothersDesignation,
                MothersDob = user.MothersDob,
                MothersMobno = user.MothersMobno,
                MothersName = user.MothersName,
                MothersOffaddress = user.MothersOffaddress,
                MothersProfession = user.MothersProfession,
                MothersResaddress = user.MothersResaddress,
                FathersMobno = user.FathersMobno,
                FamilyDoc = user.FamilyDoc,
                FathersDesignation = user.FathersDesignation,
                FathersDob = user.FathersDob,
                FathersName = user.FathersName,
                FathersProfession = user.FathersProfession,
                FathersResaddress = user.FathersResaddress,
                Gender = user.Gender,
                Height = user.Height,
                Nationality = user.Nationality,
                Relation = user.Relation,
                Religion = user.Religion,
                StudentRegNo = user.StudentRegNo,
                SamgraId = user.SamgraId,
                Section = user.Section,
                SmsDetailaltmobno = user.SmsDetailaltmobno,
                SmsDetailemail = user.SmsDetailemail,
                SmsDetailmobno = user.SmsDetailmobno,
                SmsSendername = user.SmsSendername,
                State = user.State,
                StudentAddress = user.StudentAddress,
                StudentCategory = user.StudentCategory,
                StudentDob = user.StudentDob,
                StudentImage = user.StudentImage,
                StudentName = user.StudentName,
                StudentType = user.StudentType,
                Timeofsync = user.Timeofsync
            };
            return customStudent;
        }

        Parent GetParent(CustomParent customParent)
        {
            Parent parent = new Parent()
            {
                CreatedDate = customParent.CreatedDate,
                DateOfJoin = customParent.DateOfJoin,
                Dob = customParent.Dob,
                Email = customParent.Email,
                FirstName = customParent.FirstName,
                LastLoginDate = customParent.LastLoginDate,
                 LastName = customParent.LastName ,
                  MobileNo = customParent.MobileNo ,
                  Password = customParent.Password, 
                   PhoneNo = customParent.PhoneNo,
                    Status = customParent.Status
            };

            return parent;
        }

        CustomParent GetParent(Parent Parent)
        {
            CustomParent customParent = new CustomParent()
            {
                CreatedDate = Parent.CreatedDate,
                DateOfJoin = Parent.DateOfJoin,
                Dob = Parent.Dob,
                Email = Parent.Email,
                FirstName = Parent.FirstName,
                LastLoginDate = Parent.LastLoginDate,
                LastName = Parent.LastName,
                MobileNo = Parent.MobileNo,
                Password = Parent.Password,
                PhoneNo = Parent.PhoneNo,
                Status = Parent.Status,
                Id = Parent.Id
            };
            return customParent;
        }

        #endregion
    }
}
