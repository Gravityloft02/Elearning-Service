using ERPSchoolManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Interface
{
   public interface ISchool
    {
        Task<IEnumerable<CustomSchool>> GetSchoolList();
        Task<bool> AddSchool(CustomSchool schoolRequest);
        Task<CustomSchool> GetSchool(int SchoolId);
        Task<bool> UpdateSchool(CustomSchool school);
        Task<bool> InactiveSchool(int SchoolId);
    }
}
