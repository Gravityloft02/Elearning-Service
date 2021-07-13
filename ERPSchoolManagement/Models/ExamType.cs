using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class ExamType
    {
        public ExamType()
        {
            Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
