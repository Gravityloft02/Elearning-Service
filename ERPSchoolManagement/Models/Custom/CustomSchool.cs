using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Custom
{
    public class CustomSchool
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string PrincipalName { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int LocalityId { get; set; }
        public bool? IsActive { get; set; }
        public Int64 Pincode { get; set; }
    }
}
