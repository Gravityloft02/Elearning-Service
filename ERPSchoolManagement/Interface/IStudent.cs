using ERPSchoolManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Interface
{
public interface IStudent
    {
        Task<bool> UpdateStudent(CustomStudentModel Student);
        Task<IEnumerable<CustomStudentModel>> GetStudentList();
        Task<bool> AddStudent(CustomStudentModel StudentRequest);
        Task<CustomStudentModel> GetStudent(int StudentId);

        Task<bool> UpdateParent(CustomParent Parent);
        Task<IEnumerable<CustomParent>> GetParentList();
        Task<bool> AddParent(CustomParent ParentRequest);
        Task<CustomParent> GetParent(int ParentId);
    }
}
