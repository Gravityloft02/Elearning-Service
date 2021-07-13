using ERPSchoolManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Interface
{
   public interface IManagement
    {
        Task<IEnumerable<CustomTeacher>> GetTeacherList();
        Task<bool> AddTeacher(CustomTeacher teacherRequest);
        Task<CustomTeacher> GetTeacher(int TeacherId);
        Task<bool> UpdateTeacher(CustomTeacher teacher);
        Task<IEnumerable<CustomSubject>> GetSubjectList();
        Task<bool> AddSubject(CustomSubject SubjectRequest);
        Task<CustomSubject> GetSubject(int SubjectId);

        Task<IEnumerable<CustomExamType>> GetExamTypeList();
        Task<bool> AddExamType(CustomExamType examType);
        Task<CustomExamType> GetExamType(int ExamTypeId);
        Task<bool> UpdateExamType(CustomExamType examType);
    }
}
