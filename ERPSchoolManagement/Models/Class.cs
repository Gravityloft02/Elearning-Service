using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Class
    {
        public int Id { get; set; }
        public DateTime? ClassYear { get; set; }
        public int? GradeId { get; set; }
        public int? TeacherId { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public int? SectionId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Section Section { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
