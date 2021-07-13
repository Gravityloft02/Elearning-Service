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
    public class SchoolService : ISchool
    {
        readonly SchoolManagementERPDBContext _context;

        public SchoolService(SchoolManagementERPDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddSchool(CustomSchool schoolRequest)
        {
            schoolRequest.IsActive = true;
            var _school = GetSchool(schoolRequest);
            _context.School.Add(_school);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CustomSchool> GetSchool(int SchoolId)
        {
            var _school = await _context.School.Where(x => x.Id == SchoolId).FirstOrDefaultAsync();
            var customSchool = GetSchool(_school);
            return customSchool;
        }

        public async Task<IEnumerable<CustomSchool>> GetSchoolList()
        {
            var schools = _context.School.AsEnumerable(); 
            List<CustomSchool> customSchool = new List<CustomSchool>();
            foreach (var school in schools)
            {
                customSchool.Add(GetSchool(school));
            }
            return customSchool.AsEnumerable();
        }

        public async Task<bool> InactiveSchool(int SchoolId)
        {
            var _school = await _context.School.Where(x => x.Id == SchoolId).FirstOrDefaultAsync();
            if (_school.IsActive.Value)
            {
                _school.IsActive = false;
               // _school.CreatedDate = DateTime.UtcNow;
                _context.School.Update(_school);
                var result = await _context.SaveChangesAsync();
                return (result > 0);
            }
            return false;
        }

        public async Task<bool> UpdateSchool(CustomSchool schoolRequest)
        {
            var _school = await _context.School.Where(x => x.Id == schoolRequest.Id).FirstOrDefaultAsync();
            if (_school != null)
            {
                _school.Address = schoolRequest.SchoolAddress;
                _school.SchoolName = schoolRequest.SchoolName;
                _school.IsActive = true;
                _school.LocalityId = schoolRequest.LocalityId;
                _school.StateId = schoolRequest.StateId;
                _school.CityId = schoolRequest.CityId;
                _context.School.Update(_school);
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        #region Private Functions
        School GetSchool(CustomSchool customSchool)
        {
            School school = new School()
            {

               SchoolName = customSchool.SchoolName,
               Address = customSchool.SchoolAddress,
               StateId = customSchool.StateId,
               CityId = customSchool.CityId,
               LocalityId = customSchool.LocalityId,
               IsActive = customSchool.IsActive,
               PrincipalName = customSchool.PrincipalName,
               PhoneNo = customSchool.PhoneNo,
               MobileNo = customSchool.MobileNo,
               Email = customSchool.Email
            };

            return school;
        }

        CustomSchool GetSchool(School school)
        {
            CustomSchool customSchool = new CustomSchool()
            {
                Id = school.Id,
                SchoolName = school.SchoolName,
                SchoolAddress = school.Address,
                StateId = school.StateId,
                CityId = school.CityId,
                LocalityId = school.LocalityId,
                IsActive = school.IsActive,
                PhoneNo = school.PhoneNo,
                PrincipalName = school.PrincipalName,
                Email = school.Email,
                MobileNo = school.MobileNo
            };
            return customSchool;
        }
        #endregion
    }
}
