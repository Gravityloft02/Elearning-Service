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
    public class ExamController : Controller
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly IManagement _service;
        ILocation _location;

        public ExamController(SchoolManagementERPDBContext context, IManagement service, ILocation location)
        {
            _context = context;
            _service = service;
            _location = location;
        }
        [HttpPost("ExamType/All")]
        public async Task<ActionResult<IEnumerable<CustomExamType>>> GetExamTypes()
        {
            var res = await _service.GetExamTypeList();
            return Ok(res);
        }

        [HttpPost("ExamType/{id}")]
        public async Task<ActionResult<CustomExamType>> GetExamTypes([FromRoute] int id)
        {
            var teacher = await _service.GetExamType(id);

            return Ok(teacher);
        }

        [HttpPost("ExamType/Add")]
        public async Task<ActionResult<bool>> PostExamType(CustomExamType examType)
        {
            var result = await _service.AddExamType(examType);
            return Ok(result);

        }

        [HttpPost("ExamType/Update")]
        public async Task<ActionResult<bool>> UpdateExamType(CustomExamType examType)
        {
            var result = await _service.UpdateExamType(examType);
            return Ok(result);

        }
    }
}
