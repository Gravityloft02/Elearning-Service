using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int LocalityId { get; set; }
        public bool? IsActive { get; set; }
        public string PrincipalName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }

        public virtual City City { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual State State { get; set; }
    }
}
