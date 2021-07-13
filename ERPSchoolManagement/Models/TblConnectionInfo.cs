using System;
using System.Collections.Generic;

#nullable disable

namespace ERPSchoolManagement.Models
{
    public partial class TblConnectionInfo
    {
        public int Sno { get; set; }
        public string ServerName { get; set; }
        public string ConnectionString { get; set; }
        public string FinancialYear { get; set; }
        public string SchoolCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
