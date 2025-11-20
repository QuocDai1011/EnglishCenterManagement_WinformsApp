using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    internal class CommuneDistrict
    {
        public int CommuneDistrictId { get; set; }
        public string CommuneDistrictName { get; set; }

        // Khóa ngoại
        public int ProvinceCityId { get; set; }

        // Navigation property
        public ProvinceCity ProvinceCity { get; set; }
    }
}
