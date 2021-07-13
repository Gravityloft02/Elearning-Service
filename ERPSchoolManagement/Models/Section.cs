using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Section
    {
        public Section()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string SectionName { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
