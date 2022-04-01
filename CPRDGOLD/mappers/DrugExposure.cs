using CPRDGOLD.mergers;
using DBMS;
using System;
using System.Linq;
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
            string[] cols = new string[] { "sig", "provider_id", "drug_exposure_id", "drug_source_value",
                "person_id", "drug_source_concept_id", "drug_exposure_start_date", "drug_concept_id", "drug_exposure_start_datetime",
                "drug_exposure_end_date", "drug_exposure_end_datetime", "drug_type_concept_id",};
            DB.Target.CopyBinaryRows<DrugExposure>(cols, (row, write) =>
            {
                StemTableMerger.LoopAll(chunk, stem =>
                {
                    if (null == stem.domain_id || !stem.domain_id.HasString("drug")) return;
                    row();

                    write(stem.sig);
                    write(stem.provider_id);
                    write(stem.id);
                    write(stem.source_value);
                    write(stem.person_id);
                    write(stem.source_concept_id);
                    write(stem.start_date);
                    write(stem.concept_id);
                    write(stem.start_datetime);
                    write(DateTime.TryParse(stem.end_date, out DateTime dt1) ? dt1 : default);
                    write(DateTime.TryParse(stem.end_date, out DateTime dt2) ? dt2 : default);
                    write(stem.type_concept_id);
                });
            });
        }

        public void Dependency() => chunk.Implement(LoadType.DRUGERA, () => FileQuery.ExecuteFile(Script.ForCPRDGOLD<DrugEra>(), new string[][] { new string[] { @"{ch}", chunk.ordinal.ToString() } }));
    }
}
