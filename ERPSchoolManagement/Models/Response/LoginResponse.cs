using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Response
{
    public class LoginResponse
    {
        public bool IsLoginSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Profile { get; set; }
    }
}
