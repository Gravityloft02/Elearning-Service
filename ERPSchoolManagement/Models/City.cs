using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class City
    {
        public City()
        {
            Locality = new HashSet<Locality>();
            School = new HashSet<School>();
            UserRegistration = new HashSet<UserRegistration>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int? StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Locality> Locality { get; set; }
        public virtual ICollection<School> School { get; set; }
        public virtual ICollection<UserRegistration> UserRegistration { get; set; }
    }
}
