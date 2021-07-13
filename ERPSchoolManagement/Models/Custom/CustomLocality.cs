using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSchoolManagement.Models.Custom
{
    public class CustomLocality
    {
        public int Id { get; set; }
        public string LocalityName { get; set; }
        public int? StateId { get; set; }
        public int CityId { get; set; }
        public long? Pincode { get; set; }
    }
}
