using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Response
{
    public class UserRegistrationResponse
    {
        public bool IsRegistered { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
