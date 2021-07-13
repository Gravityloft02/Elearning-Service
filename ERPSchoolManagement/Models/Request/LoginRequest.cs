using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Request
{
    public class LoginRequest
    {
        public string LoginId { get; set; }
        public string SchoolCode { get; set; }
        public int RoleId { get; set; }
        public string Session_Year { get; set; }
        public string Password { get; set; }
    }
}
