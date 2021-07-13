using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Locality
    {
        public Locality()
        {
            School = new HashSet<School>();
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int Id { get; set; }
        public string LocalityName { get; set; }
        public int? StateId { get; set; }
        public int CityId { get; set; }
        public long? Pincode { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<School> School { get; set; }
        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
