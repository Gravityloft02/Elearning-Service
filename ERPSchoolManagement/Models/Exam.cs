using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamResult = new HashSet<ExamResult>();
        }

        public int Id { get; set; }
        public int? ExamTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ExamDate { get; set; }

        public virtual ExamType ExamType { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
    }
}
