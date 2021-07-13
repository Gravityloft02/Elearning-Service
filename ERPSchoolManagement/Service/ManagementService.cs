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
    public class ManagementService:IManagement
    {
        readonly SchoolManagementERPDBContext _context;

        public ManagementService(SchoolManagementERPDBContext context)
        {
            _context = context;
        }

        #region Subject
        public async Task<bool> AddSubject(CustomSubject SubjectRequest)
        {
            var _sub = GetSubject(SubjectRequest);
            _context.Subject.Add(_sub);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomSubject> GetSubject(int SubjectId)
        {
            var _subject = await _context.Subject.Where(x => x.Id == SubjectId).FirstOrDefaultAsync();
            var customSubject = GetSubject(_subject);
            return customSubject;
        }

        public async Task<IEnumerable<CustomSubject>> GetSubjectList()
        {
            var subjects = _context.Subject.AsEnumerable();
            List<CustomSubject> customSubject = new List<CustomSubject>();
            foreach (var sub in subjects)
            {
                customSubject.Add(GetSubject(sub));
            }
            return customSubject.AsEnumerable();
        }

        #endregion

        #region Teacher

        public async Task<bool> AddTeacher(CustomTeacher teacherRequest)
        {
            var _teacher = GetTeacher(teacherRequest);
            _context.Teacher.Add(_teacher);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<CustomTeacher> GetTeacher(int TeacherId)
        {
            var _teacher = await _context.Teacher.Where(x => x.Id == TeacherId).FirstOrDefaultAsync();
            var customTeacher = GetTeacher(_teacher);
            return customTeacher;
        }

        public async Task<IEnumerable<CustomTeacher>> GetTeacherList()
        {
            var teachers = _context.Teacher.AsEnumerable();
            List<CustomTeacher> customTeacher = new List<CustomTeacher>();
            foreach (var teacher in teachers)
            {
                customTeacher.Add(GetTeacher(teacher));
            }
            return customTeacher.AsEnumerable();
        }



        public async Task<bool> UpdateTeacher(CustomTeacher teacher)
        {
            var _teacher = await _context.Teacher.Where(x => x.Id == teacher.Id).FirstOrDefaultAsync();
            if (_teacher != null)
            {
                _teacher.CreatedDate = teacher.CreatedDate;
                _teacher.DateOfJoin = teacher.DateOfJoin;
                _teacher.Dob = teacher.Dob;
                _teacher.Email = teacher.Email;
                _teacher.Password = teacher.Password;
                _teacher.FirstName = teacher.FirstName;
                _teacher.LastLoginDate = teacher.LastLoginDate;
                _teacher.LastName = teacher.LastName;
                _teacher.MobileNo = teacher.MobileNo;
                _teacher.PhoneNo = teacher.PhoneNo;
                _teacher.Status = teacher.Status;

            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }


        #endregion

        #region Exam
        public async Task<bool> AddExamType(CustomExamType examType)
        {
            var _examtype = GetExamType(examType);
            _context.ExamType.Add(_examtype);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<CustomExamType> GetExamType(int ExamTypeId)
        {
            var _examtype = await _context.ExamType.Where(x => x.Id == ExamTypeId).FirstOrDefaultAsync();
            var customExamType = GetExamType(_examtype);
            return customExamType;
        }

        public async Task<IEnumerable<CustomExamType>> GetExamTypeList()
        {
            var ExamTypes = _context.ExamType.AsEnumerable();
            List< CustomExamType> customExamTypes = new List<CustomExamType>();
            foreach (var ExamType in ExamTypes)
            {
                customExamTypes.Add(GetExamType(ExamType));
            }
            return customExamTypes.AsEnumerable();
        }



        public async Task<bool> UpdateExamType(CustomExamType examType)
        {
            var _ExamType = await _context.ExamType.Where(x => x.Id == examType.Id).FirstOrDefaultAsync();
            if (_ExamType != null)
            {
                _ExamType.Description = examType.Description;
                _ExamType.Name = examType.Name;
                
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
        Subject GetSubject(CustomSubject customSubject)
        {
            Subject subject = new Subject()
            {
                Description = customSubject.Description,
                GradeId = customSubject.GradeId,
                SubjectName = customSubject.SubjectName
            };

            return subject;
        }

        CustomSubject GetSubject(Subject subject)
        {
            CustomSubject customSubject = new CustomSubject()
            {
                Description = subject.Description,
                Id = subject.Id,
                GradeId = subject.GradeId,
                SubjectName = subject.SubjectName
            };
            return customSubject;
        }

        Teacher GetTeacher(CustomTeacher customTeacher)
        {
            Teacher teacher = new Teacher()
            {
                CreatedDate = customTeacher.CreatedDate,
                DateOfJoin = customTeacher.DateOfJoin,
                Dob = customTeacher.Dob,
                Email = customTeacher.Email,
                FirstName = customTeacher.FirstName,
                LastLoginDate = customTeacher.LastLoginDate,
                LastName = customTeacher.LastName,
                MobileNo = customTeacher.MobileNo,
                Password = customTeacher.Password,
                PhoneNo = customTeacher.PhoneNo,
                Status = customTeacher.Status
            };

            return teacher;
        }

        CustomTeacher GetTeacher(Teacher teacher)
        {
            CustomTeacher customTeacher = new CustomTeacher()
            {
                CreatedDate = teacher.CreatedDate,
                DateOfJoin = teacher.DateOfJoin,
                Dob = teacher.Dob,
                Email = teacher.Email,
                PhoneNo = teacher.PhoneNo ,
                Password = teacher.Password, 
                MobileNo = teacher.MobileNo,
                FirstName = teacher.FirstName,
                LastLoginDate = teacher.LastLoginDate,
                LastName = teacher.LastName,
                Id = teacher.Id,
                Status = teacher.Status
            };
            return customTeacher;
        }

        ExamType GetExamType(CustomExamType customExamType)
        {
            ExamType exam = new ExamType()
            {
                Description = customExamType.Description,
                Name = customExamType.Name
            };

            return exam;
        }

        CustomExamType GetExamType(ExamType examType)
        {
            CustomExamType customExamType = new CustomExamType()
            {
                Description = examType.Description,
                Id = examType.Id,
                Name = examType.Name
            };
            return customExamType;
        }
        #endregion
    }
}
