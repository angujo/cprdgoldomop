using CPRDGOLD.mergers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mappers
{
    internal class DrugExposure : Mapper<DrugExposure>
    {
        public int? days_supply { get; set; }
        public string dose_unit_source_value { get; set; }
        public int drug_concept_id { get; set; }
        public DateTime drug_exposure_end_date { get; set; }
        public DateTime? drug_exposure_end_datetime { get; set; }
        public long drug_exposure_id { get; set; }
        public DateTime drug_exposure_start_date { get; set; }
        public DateTime? drug_exposure_start_datetime { get; set; }
        public int? drug_source_concept_id { get; set; }
        public string drug_source_value { get; set; }
        public int drug_type_concept_id { get; set; }
        public string lot_number { get; set; }
        public long person_id { get; set; }
        public long provider_id { get; set; }
        public decimal? quantity { get; set; }
        public int? refills { get; set; }
        public int? route_concept_id { get; set; }
        public string route_source_value { get; set; }
        public string sig { get; set; }
        public string stop_reason { get; set; }
        public DateTime verbatim_end_date { get; set; }
        public long visit_detail_id { get; set; }
        public long visit_occurrence_id { get; set; }

        protected override void LoadData()
        {
            StemTableMerger.LoopAll(chunk, stem =>
            {
                if (!new string[] { "Drug" }.Contains(stem.domain_id)) return;
                Add(new DrugExposure
                {
                    sig = stem.sig,
                    provider_id = stem.provider_id,
                    visit_occurrence_id = stem.visit_occurrence_id,
                    quantity = null,
                    drug_exposure_id = stem.id,
                    drug_source_value = stem.source_value,
                    person_id = stem.person_id,
                    drug_source_concept_id = (int)stem.source_concept_id,
                    drug_exposure_start_date = stem.start_date,
                    drug_concept_id = (int)stem.concept_id,
                    drug_exposure_start_datetime = stem.start_datetime,
                    drug_exposure_end_date = string.IsNullOrEmpty(stem.end_date) ? default : DateTime.Parse(stem.end_date),
                    drug_exposure_end_datetime = string.IsNullOrEmpty(stem.end_date) ? default : DateTime.Parse(stem.end_date),
                    drug_type_concept_id = (int)stem.type_concept_id,
                    visit_detail_id = 0,
                });
            });
        }

        public void Dependency() => DBMS.FileQuery.ExecuteFile(Script.ForCPRDGOLD<DrugEra>(), new string[][] { new string[] { @"{ch}", chunk.ordinal.ToString() } });
    }
}
