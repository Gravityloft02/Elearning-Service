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
    public class ParentController : ControllerBase
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly IStudent _service;
        ILocation _location;

        public ParentController(SchoolManagementERPDBContext context, IStudent service, ILocation location)
        {
            _context = context;
            _service = service;
            _location = location;
        }
        [HttpPost("All")]
        public async Task<ActionResult<IEnumerable<CustomParent>>> GetParents()
        {
            var res = await _service.GetParentList();
            return Ok(res);
        }

        [HttpPost("parent/{id}")]
        public async Task<ActionResult<CustomParent>> GetParents([FromRoute] int id)
        {
            var teacher = await _service.GetParent(id);

            return Ok(teacher);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<bool>> PostParent(CustomParent parent)
        {
            var result = await _service.AddParent(parent);
            return Ok(result);

        }

        [HttpPost("Update")]
        public async Task<ActionResult<bool>> UpdateParent(CustomParent parent)
        {
            var result = await _service.UpdateParent(parent);
            return Ok(result);

        }
    }
}
