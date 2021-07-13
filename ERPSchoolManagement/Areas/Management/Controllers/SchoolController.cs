using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace ERPSchoolManagement.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly ISchool _school;
        ILocation _location;

        public SchoolController(SchoolManagementERPDBContext context, ISchool school,ILocation location)
        {
            _context = context;
            _school = school;
            _location = location;
        }

     [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomSchool>>> GetSchools()
        {
            var res = await _school.GetSchoolList();
            return Ok(res);
        }
        
        [HttpPost("school/{id}")]
        public async Task<ActionResult<CustomSchool>> GetSchools([FromRoute] int id)
        {
            var school = await _school.GetSchool(id);

            return Ok(school);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostSchool(CustomSchool school)
        {
            var result = await _school.AddSchool(school);
            return Ok(result);

        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> UpdateSchool(CustomSchool school)
        {
            var result = await _school.UpdateSchool(school);
            return Ok(result);
        }

        [HttpPost("Inactive/{id}")]
        public async Task<ActionResult<bool>> InactiveSchool([FromRoute] int id)
        {
            var res = await _school.InactiveSchool(id);
            return Ok(res);
        }

    }
}
