using ERPSchoolManagement.Interface;
using ERPSchoolManagement.Models;
using ERPSchoolManagement.Models.Custom;
using ERPSchoolManagement.Models.Request;
using ERPSchoolManagement.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[controller]")]
    [ApiController]
    public class AdminRegistrationController : ControllerBase
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly ISchool _school;
        private readonly IRegistration _registration;
        ILocation _location;
        public AdminRegistrationController(SchoolManagementERPDBContext context, ISchool school, ILocation location, IRegistration registration)
        {
            _context = context;
            _school = school;
            _location = location;
            _registration = registration;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserRegistrationResponse>> PostAdminUserRegistration([FromBody] CustomUserModel registration)
        {
            var user = await _registration.RegisterAdminUser(registration);
            return Ok(user);
        }
    }
}
