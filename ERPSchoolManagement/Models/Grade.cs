using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Class = new HashSet<Class>();
            Subject = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}
