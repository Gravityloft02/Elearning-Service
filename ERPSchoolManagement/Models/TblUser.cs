using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class TblUser
    {
        public int Sno { get; set; }
        public string Userid { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FinancialYear { get; set; }
        public int? PrintPermission { get; set; }
        public int? ModifyPermisson { get; set; }
        public int? DeletePermission { get; set; }
        public int? ReportPermission { get; set; }
        public string BrachId { get; set; }
        public string City { get; set; }
        public string Usertype { get; set; }
        public int? Status { get; set; }
        public DateTime? WindowsAppLoginTime { get; set; }
        public DateTime? WebAppLoginTime { get; set; }
        public string WindowsPermission { get; set; }
        public string WebPermission { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
    }
}
