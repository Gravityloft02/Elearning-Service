using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class Student
    {
        public Student()
        {
            ExamResult = new HashSet<ExamResult>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public int? ParentId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public bool? Status { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
    }
}
