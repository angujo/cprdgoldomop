using CPRDGOLD.loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class CareSite : Mapper<CareSite>
    {
        public long care_site_id { get; set; }
        public string care_site_name { get; set; }
        public string care_site_source_value { get; set; }
        public long location_id { get; set; }
        public int? place_of_service_concept_id { get; set; }
        public string place_of_service_source_value { get; set; }

        protected override void LoadData()
        {
            PracticeLoader.LoopAll(pract =>
            {
                Add(new CareSite
                {
                    care_site_id = pract.pracid,
                    place_of_service_concept_id = pract.region,
                    location_id = 8977,
                    care_site_source_value = pract.pracid.ToString(),
                });
            });
        }
    }
}
