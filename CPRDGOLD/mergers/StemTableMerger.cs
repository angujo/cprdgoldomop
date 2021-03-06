using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CPRDGOLD.loaders;
using CPRDGOLD.models;
using DBMS.models;
using Util;

namespace CPRDGOLD.mergers
{
    internal class StemTableMerger : ChunkMerger<StemTableMerger, StemTable>
    {
        //  protected AddInMerger addInMerger;
        protected StemTableMerger(Chunk chunk) : base(chunk)
        {
        }

        public StemTableMerger()
        {
        }

        protected override void LoadData()
        {
        }

        public static StemTableMerger Prepare(Chunk chunk)
        {
            var stem = Init(chunk);
            chunk.Log.Info("Starting StemTable Creator");
            var actions = new List<Action>
            {
                () => stem.Additional(),
                () => stem.Clinical(),
                () => stem.Immunisation(),
                () => stem.Referral(),
                () => stem.Test(),
                () => stem.Therapy(),
            };
            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
            chunk.Log.Info($"Total Data StemTable [{stem.data.Count}]");
            chunk.Log.Info("Finished StemTable Creator");
            return stem;
        }

        private void Additional()
        {
            var addInMerger = AddInMerger.prepare(chunk);

            chunk.Log.Info("Starting StemTable #Additional");
            addInMerger.LoopAllFast(add_in =>
            {
                var concept  = ConceptLoader.ByCode(add_in.source_value) ?? new Concept();
                var concUcum = ConceptLoader.ByStdCodeVocab(add_in.unit_source_value, "UCUM") ?? new Concept();
                Add(new StemTable
                {
                    domain_id          = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id          = add_in.patid,
                    start_datetime     = add_in.eventdate,
                    concept_id         = add_in.st_target_concept_id ?? 0,
                    source_value       = add_in.source_value,
                    source_concept_id  = 0,
                    type_concept_id    = 32851,
                    start_date         = add_in.eventdate,
                    unit_concept_id    = concUcum.concept_id.ToString(),
                    unit_source_value  = add_in.unit_source_value,
                    end_date           = add_in.eventdate.ToString("yyyy-mm-dd"),
                    provider_id        = add_in.staffid,
                    value_as_number    = add_in.value_as_number,
                    value_source_value = add_in.qualifier_source_value,
                    value_as_string    = add_in.value_as_string,
                    chunk_identifier   = add_in.chunk_identifier,
                });
            });
            chunk.Log.Info("Finished StemTable #Additional");
        }

        private void Clinical()
        {
            chunk.Log.Info("Starting StemTable #Clinical");
            chunk.GetLoader<ClinicalLoader>(ChunkLoadType.CLINICAL).LoopAllFast(clinic =>
            {
                var stem = new StemTable
                {
                    domain_id         = clinic.conc_domain_id,
                    person_id         = clinic.patid,
                    provider_id       = clinic.staffid,
                    start_datetime    = clinic.eventdate,
                    concept_id        = clinic.st_target_concept_id ?? 0,
                    source_value      = clinic.med_read_code,
                    source_concept_id = clinic.ss_source_concept_id ?? 0,
                    type_concept_id   = 32827,
                    start_date        = clinic.eventdate,
                    chunk_identifier  = clinic.chunk_identifier,
                };
                Add(stem);
            });
            chunk.Log.Info("Finished StemTable #Clinical");
        }

        private void Immunisation()
        {
            chunk.Log.Info("Starting StemTable #Immunisation");
            chunk.GetLoader<ImmunisationLoader>(ChunkLoadType.IMMUNISATION).LoopAllFast(imm =>
            {
                Add(new StemTable
                {
                    domain_id         = imm.conc_domain_id,
                    person_id         = imm.patid,
                    provider_id       = imm.staffid,
                    start_datetime    = imm.eventdate,
                    concept_id        = imm.st_target_concept_id ?? 0,
                    source_value      = imm.med_read_code,
                    source_concept_id = imm.ss_source_concept_id ?? 0,
                    type_concept_id   = 32827,
                    start_date        = imm.eventdate,
                    chunk_identifier  = imm.chunk_identifier,
                });
            });
            chunk.Log.Info("Finished StemTable #Immunisation");
        }

        private void Referral()
        {
            chunk.Log.Info("Starting StemTable #Referral");
            chunk.GetLoader<ReferralLoader>(ChunkLoadType.REFERRAL).LoopAllFast(reff =>
            {
                Add(new StemTable
                {
                    domain_id         = reff.conc_domain_id,
                    person_id         = reff.patid,
                    provider_id       = reff.staffid,
                    start_datetime    = reff.eventdate,
                    concept_id        = reff.st_target_concept_id ?? 0,
                    source_value      = reff.med_read_code,
                    source_concept_id = reff.ss_source_concept_id ?? 0,
                    type_concept_id   = 32842,
                    start_date        = reff.eventdate,
                    chunk_identifier  = reff.chunk_identifier,
                });
            });
            chunk.Log.Info("Finished StemTable #Referral");
        }

        private void Test()
        {
            chunk.Log.Info("Starting StemTable #Test");
            TestIntMerger
                .Init(chunk)
                .LoopAllFast(test =>
                {
                    var concUcum = ConceptLoader.ByStdCodeVocab(test.unit, "UCUM") ?? new Concept();
                    var concVal = ConceptLoader.ByStdNameDomain(test.value_as_concept_id, "Meas Value") ??
                                  new Concept();
                    Add(new StemTable
                    {
                        domain_id           = test.conc_domain_id,
                        person_id           = test.patid,
                        provider_id         = test.staffid,
                        start_datetime      = test.eventdate,
                        concept_id          = test.st_target_concept_id,
                        source_value        = test.read_code,
                        source_concept_id   = test.ss_source_concept_id,
                        type_concept_id     = 32856,
                        start_date          = test.eventdate,
                        operator_concept_id = test.OperatorConceptId.ToString(),
                        unit_concept_id     = concUcum.concept_id.ToString(),
                        unit_source_value   = test.unit,
                        range_high          = test.range_high,
                        range_low           = test.range_low,
                        value_as_concept_id = concVal.concept_id.ToString(),
                        value_as_number     = test.value_as_number,
                        value_source_value  = test.value_as_concept_id,
                        chunk_identifier    = test.chunk_identifier,
                    });
                });
            chunk.Log.Info("Finished StemTable #Test");
        }

        private void Therapy()
        {
            chunk.Log.Info("Starting StemTable #Therapy");
            chunk.GetLoader<TherapyLoader>(ChunkLoadType.THERAPY).LoopAllFast(ther =>
            {
                var cdosage = CommonDosageLoader.ByDoseId(ther.dosageid);
                var ddecode =
                    DaySupplyDecodeLoader.ByAll((int) ther.prodcode,
                                                Int32.TryParse($"{cdosage?.daily_dose}", out var dd) ? dd : 0,
                                                (int?) ther.qty, (int?) ther.numpacks) ?? new DaySupplyDecode();
                var dmode = DaySupplyModeLoader.ByProdcode((int) ther.prodcode) ?? new DaySupplyMode();
                Add(new StemTable
                {
                    domain_id         = ther.conc_domain_id,
                    person_id         = ther.patid,
                    provider_id       = ther.staffid,
                    start_datetime    = ther.eventdate,
                    concept_id        = ther.st_target_concept_id ?? 0,
                    source_value      = ther.prod_gemscriptcode,
                    source_concept_id = ther.ss_source_concept_id ?? 0,
                    type_concept_id   = 32838,
                    start_date        = ther.eventdate,
                    end_date = ther.eventdate
                                   .AddDays((double) (null != ther.numdays && 0 < ther.numdays && 365 > ther.numdays
                                                ? ther.numdays
                                                : (0 != ddecode.numdays ? ddecode.numdays : dmode.numdays))).ToString(),
                    sig              = cdosage?.dosage_text,
                    chunk_identifier = ther.chunk_identifier,
                });
            });
            chunk.Log.Info("Finished StemTable #Therapy");
        }
    }
}