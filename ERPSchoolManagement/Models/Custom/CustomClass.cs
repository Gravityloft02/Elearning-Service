using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Custom
{
    public class CustomClass
    {
        public int Id { get; set; }
        public DateTime? ClassYear { get; set; }
        public int? GradeId { get; set; }
        public int? TeacherId { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public int? SectionId { get; set; }
    }
}
