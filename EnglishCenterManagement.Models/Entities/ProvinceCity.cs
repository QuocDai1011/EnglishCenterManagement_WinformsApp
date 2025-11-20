using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Entities
{
    internal class ProvinceCity
    {
        public int ProvinceCityId { get; set; }
        public string ProvinceCityName { get; set; }

        // Navigation property: Một tỉnh có nhiều quận/huyện
        public ICollection<CommuneDistrict> CommuneDistricts { get; set; } = new List<CommuneDistrict>();
    }
}
