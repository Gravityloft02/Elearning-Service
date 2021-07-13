using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class UserRegistration
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

        public virtual City City { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual UserRoles Role { get; set; }
        public virtual State State { get; set; }
    }
}
