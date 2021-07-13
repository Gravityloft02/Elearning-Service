using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Custom
{
    public class CustomUserRegistration
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public long RoleId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int LocalityId { get; set; }
        public string Pincode { get; set; }
        public bool IsState { get; set; }
        public bool IsCity { get; set; }
        public bool IsLocality { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string LocalityName { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
