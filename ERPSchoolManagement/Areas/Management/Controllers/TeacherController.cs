using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Areas.Management.Controllers
{
    [Area("Management")]
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly IManagement _service;
        ILocation _location;

        public TeacherController(SchoolManagementERPDBContext context, IManagement service, ILocation location)
        {
            _context = context;
            _service = service;
            _location = location;
        }
        [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomTeacher>>> GetTeachers()
        {
            var res = await _service.GetTeacherList();
            return Ok(res);
        }

        [HttpPost("teacher/{id}")]
        public async Task<ActionResult<CustomTeacher>> GetTeachers([FromRoute] int id)
        {
            var teacher = await _service.GetTeacher(id);

            return Ok(teacher);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostTeacher(CustomTeacher teacher)
        {
            var result = await _service.AddTeacher(teacher);
            return Ok(result);

        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> UpdateTeacher(CustomTeacher teacher)
        {
            var result = await _service.UpdateTeacher(teacher);
            return Ok(result);

        }
    }
}
