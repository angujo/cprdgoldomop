using CPRDGOLD.mergers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.mappers
{
    internal class Specimen : Mapper<Specimen>
    {
        public int? anatomic_site_concept_id { get; set; }
        public string anatomic_site_source_value { get; set; }
        public int? disease_status_concept_id { get; set; }
        public string disease_status_source_value { get; set; }
        public long person_id { get; set; }
        public decimal? quantity { get; set; }
        public int specimen_concept_id { get; set; }
        public DateTime specimen_date { get; set; }
        public DateTime? specimen_datetime { get; set; }
        public long specimen_id { get; set; }
        public string specimen_source_id { get; set; }
        public string specimen_source_value { get; set; }
        public int specimen_type_concept_id { get; set; }
        public int? unit_concept_id { get; set; }
        public string unit_source_value { get; set; }

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Specimen" }.Contains(stem.domain_id)) return;
                Add(new Specimen
                {
                    specimen_id = stem.id,
                    specimen_source_value = stem.source_value,
                    person_id = stem.person_id,
                    specimen_date = stem.start_date,
                    specimen_concept_id = (int)stem.concept_id,
                    specimen_datetime = stem.start_datetime,
                    specimen_type_concept_id = (int)stem.type_concept_id,
                    unit_concept_id = int.TryParse(stem.unit_concept_id, out int uc) ? uc : default,
                    unit_source_value = stem.unit_source_value,
                });
            });
        }
    }
}
