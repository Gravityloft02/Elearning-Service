using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ExamResult = new HashSet<ExamResult>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int? GradeId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
    }
}
