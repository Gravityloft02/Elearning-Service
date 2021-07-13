using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            Locality = new HashSet<Locality>();
            School = new HashSet<School>();
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Locality> Locality { get; set; }
        public virtual ICollection<School> School { get; set; }
        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
