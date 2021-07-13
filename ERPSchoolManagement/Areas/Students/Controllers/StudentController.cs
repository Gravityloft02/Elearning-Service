using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Areas.Students.Controllers
{
    [Area("Students")]
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
        private readonly SchoolManagementERPDBContext _context;
        private readonly IStudent _service;
        ILocation _location;

        public StudentController(SchoolManagementERPDBContext context, IStudent service, ILocation location)
        {
            _context = context;
            _service = service;
            _location = location;
        }
        [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomStudentModel>>> GetStudents()
        {
            var res = await _service.GetStudentList();
            return Ok(res);
        }

        [HttpPost("Student/{id}")]
        public async Task<ActionResult<CustomStudentModel>> GetStudents([FromRoute] int id)
        {
            var teacher = await _service.GetStudent(id);

            return Ok(teacher);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostStudent(CustomStudentModel Student)
        {
            var result = await _service.AddStudent(Student);
            return Ok(result);

        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> UpdateStudent(CustomStudentModel Student)
        {
            var result = await _service.UpdateStudent(Student);
            return Ok(result);

        }
    }
}
