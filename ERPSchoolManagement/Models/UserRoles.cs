using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class UserRoles
    {
        public UserRoles()
        {
            UserRegistration = new HashSet<UserRegistration>();
        }

        public long Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
