using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class ExamResult
    {
        public int Id { get; set; }
        public int? ExamId { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public string Marks { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
