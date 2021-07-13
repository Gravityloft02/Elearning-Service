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
    public class SubjectController : Controller
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly IManagement _service;
        ILocation _location;

        public SubjectController(SchoolManagementERPDBContext context, IManagement service, ILocation location)
        {
            _context = context;
            _service = service;
            _location = location;
        }
        [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomSubject>>> GetSubjects()
        {
            var res = await _service.GetSubjectList();
            return Ok(res);
        }

        [HttpPost("subject/{id}")]
        public async Task<ActionResult<CustomSubject>> GetSubject([FromRoute] int id)
        {
            var sub = await _service.GetSubject(id);

            return Ok(sub);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostSubject(CustomSubject subject)
        {
            var result = await _service.AddSubject(subject);
            return Ok(result);

        }
    }
}
