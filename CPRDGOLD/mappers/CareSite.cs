using CPRDGOLD.loaders;
using DBMS;

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
            PracticeLoader.Init();
            string[] cols = new string[] { "care_site_id", "place_of_service_concept_id", "location_id", "care_site_source_value", };
            DB.Target.CopyBinaryRows<CareSite>(cols, (row, write) =>
            {
                PracticeLoader.LoopAll(pract =>
                {
                    row();
                    write(pract.pracid);
                    write(pract.region);
                    write((long)8977);
                    write(pract.pracid.ToString());
                });
            });
        }
    }
}
