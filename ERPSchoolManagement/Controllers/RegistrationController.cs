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

namespace ERPSchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly SchoolManagementERPDBContext _context;
        private readonly ISchool _school;
        private readonly IRegistration _registration;
        ILocation _location;


        public RegistrationController(SchoolManagementERPDBContext context, ISchool school, ILocation location, IRegistration registration)
        {
            _context = context;
            _school = school;
            _location = location;
            _registration = registration;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> ValidateUserLogin([FromBody] LoginRequest request)
        {
            
            var user = await _registration.LoginUser(request);
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserRegistrationResponse>> PostUserRegistration([FromBody]CustomUserRegistration  registration)
        {
            var user = await _registration.RegisterUser(registration);
            return Ok(user);
        }

        [HttpPost("UserRole/All")]
        public async Task<ActionResult<IEnumerable<CustomUserRole>>> UserRoleList()
        {
            var roles = await _registration.GetUserRoles();
            return Ok(roles);
        }
    }
}
