using CPRDGOLD.loaders;
using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mergers
{
    internal class StemTableMerger : ChunkMerger<StemTableMerger, StemTable>
    {
        protected StemTableMerger(Chunk chunk) : base(chunk) { }
        public StemTableMerger() : base() { }
        protected override void Load() { }

        public static void Prepare(Chunk chunk)
        {
            Log.Info($"Starting StemTable Creator");
            List<Action> actions = new List<Action> {
                ()=>GetMe(chunk).Additional(),
                ()=>GetMe(chunk).Clinical(),
                ()=>GetMe(chunk).Immunisation(),
                ()=>GetMe(chunk).Referral(),
                ()=>GetMe(chunk).Test(),
                ()=>GetMe(chunk).Therapy(),
            };
            Parallel.ForEach(actions, action => action());
            Log.Info($"Finished StemTable Creator");
        }

        private void Additional()
        {
            AddInMerger.prepare(chunk);

            Log.Info($"Starting StemTable #Additional");
            AddInMerger.LoopAll(chunk, add_in =>
            {
                SourceToStandard std = SourceToStandardLoader.BySourceCodeTargetVocab(add_in.source_value, "JNJ_CPRD_ADD_ENTTYPE");
                if (null == std) return;
                Concept concept = ConceptLoader.ByCode(add_in.source_value) ?? new Concept();
                Concept concUcum = ConceptLoader.ByStdCodeVocab(add_in.unit_source_value, "UCUM") ?? new Concept();
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = add_in.patid,
                    start_datetime = add_in.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = add_in.source_value,
                    source_concept_id = 0,
                    type_concept_id = 32851,
                    start_date = add_in.eventdate,
                    unit_concept_id = concUcum.concept_id.ToString(),
                    unit_source_value = add_in.unit_source_value,
                    end_date = add_in.eventdate.ToString("yyyy-mm-dd"),
                    provider_id = add_in.staffid,
                    value_as_number = add_in.value_as_number,
                    value_source_value = add_in.qualifier_source_value,
                    value_as_string = add_in.value_as_string,
                });
            });
            Log.Info($"Finished StemTable #Additional");
        }

        private void Clinical()
        {
            Log.Info($"Starting StemTable #Clinical");
            ClinicalLoader.LoopAll(chunk, clinical =>
            {
                Medical med = MedicalLoader.ByMedcode(clinical.medcode);
                if (null == med) return;
                SourceToStandard std = SourceToStandardLoader.BySourceCodeSourceVocab(med.read_code, "Read");
                if (null == std) return;
                Concept concept = ConceptLoader.ByStdCode(med.read_code) ?? new Concept();
                SourceToSource ssource = SourceToSourceLoader.BySourceCodeSourceVocab(med.read_code, "Read") ?? new SourceToSource();
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = clinical.patid,
                    provider_id = clinical.staffid,
                    start_datetime = clinical.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = med.read_code,
                    source_concept_id = ssource.source_concept_id ?? 0,
                    type_concept_id = 32827,
                    start_date = clinical.eventdate,
                });
            });
            Log.Info($"Finished StemTable #Clinical");
        }

        private void Immunisation()
        {
            Log.Info($"Starting StemTable #Immunisation");
            ImmunisationLoader.LoopAll(chunk, imm =>
            {
                Medical med = MedicalLoader.ByMedcode(imm.medcode);
                if (null == med) return;
                SourceToStandard std = SourceToStandardLoader.BySourceCodeSourceVocab(med.read_code, "Read");
                if (null == std) return;
                Concept concept = ConceptLoader.ByStdCode(med.read_code) ?? new Concept();
                SourceToSource ssource = SourceToSourceLoader.BySourceCodeSourceVocab(med.read_code, "Read") ?? new SourceToSource();
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = imm.patid,
                    provider_id = imm.staffid,
                    start_datetime = imm.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = med.read_code,
                    source_concept_id = ssource.source_concept_id,
                    type_concept_id = 32827,
                    start_date = imm.eventdate,
                });
            });
            Log.Info($"Finished StemTable #Immunisation");
        }

        private void Referral()
        {
            Log.Info($"Starting StemTable #Referral");
            ReferralLoader.LoopAll(chunk, reff =>
            {
                Medical med = MedicalLoader.ByMedcode(reff.medcode);
                if (null == med) return;
                SourceToStandard std = SourceToStandardLoader.BySourceCodeSourceVocab(med.read_code, "Read");
                if (null == std) return;
                Concept concept = ConceptLoader.ByStdCode(med.read_code) ?? new Concept();
                SourceToSource ssource = SourceToSourceLoader.BySourceCodeSourceVocab(med.read_code, "Read") ?? new SourceToSource();
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = reff.patid,
                    provider_id = reff.staffid,
                    start_datetime = reff.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = med.read_code,
                    source_concept_id = ssource.source_concept_id,
                    type_concept_id = 32842,
                    start_date = reff.eventdate,
                });
            });
            Log.Info($"Finished StemTable #Referral");
        }

        private void Test()
        {
            Log.Info($"Starting StemTable #Test");
            TestIntMerger.LoopAll(chunk, test =>
            {
                SourceToStandard std = SourceToStandardLoader.BySourceCodeTargetVocab(test.read_code, "JNJ_CPRD_TEST_ENT");
                if (null == std) return;
                Concept concept = ConceptLoader.ByStdCode(test.read_code) ?? new Concept();
                Concept concUcum = ConceptLoader.ByStdCodeVocab(test.unit, "UCUM") ?? new Concept();
                Concept concVal = ConceptLoader.ByStdNameDomain(test.value_as_concept_id, "Meas Value") ?? new Concept();
                SourceToSource ssource = SourceToSourceLoader.BySourceCodeSourceVocab(test.read_code, "Read") ?? new SourceToSource();
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = test.patid,
                    provider_id = test.staffid,
                    start_datetime = test.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = test.read_code,
                    source_concept_id = ssource.source_concept_id,
                    type_concept_id = 32856,
                    start_date = test.eventdate,
                    operator_concept_id = (string)(test.Operator == "<=" ? 4171754.ToString() : (test.Operator == ">=" ? 4171755.ToString() : (test.Operator == "<" ? 4171756.ToString() : (test.Operator == "=" ? 4172703.ToString() : (test.Operator == ">" ? 4172704.ToString() : null))))),
                    unit_concept_id = concUcum.concept_id.ToString(),
                    unit_source_value = test.unit,
                    range_high = test.range_high,
                    range_low = test.range_low,
                    value_as_concept_id = concVal.concept_id.ToString(),
                    value_as_number = test.value_as_number,
                    value_source_value = test.value_as_concept_id,
                });
            });
            Log.Info($"Finished StemTable #Test");
        }

        private void Therapy()
        {
            Log.Info($"Starting StemTable #Therapy");
            TherapyLoader.LoopAll(chunk, ther =>
            {
                Product prod = ProductLoader.ByProdcode(ther.prodcode) ?? new Product();
                SourceToStandard std = SourceToStandardLoader.BySourceCodeTargetVocab(prod.gemscriptcode, "gemscript");
                CommonDosage cdosage = CommonDosageLoader.ByDoseId(ther.dosageid);
                if (null == std || null == prod || null == cdosage) return;
                Concept concept = ConceptLoader.ByStdCode(prod.gemscriptcode) ?? new Concept();
                SourceToSource ssource = SourceToSourceLoader.BySourceCodeSourceVocab(prod.gemscriptcode, "gemscript") ?? new SourceToSource();
                DaySupplyDecode ddecode = DaySupplyDecodeLoader.ByAll((int)ther.prodcode, (int?)cdosage.daily_dose, (int?)ther.qty, (int?)ther.numpacks);
                DaySupplyMode dmode = DaySupplyModeLoader.ByProdcode((int)ther.prodcode);
                Add(new StemTable
                {
                    domain_id = 0 == concept.concept_id ? "Observation" : concept.domain_id,
                    person_id = ther.patid,
                    provider_id = ther.staffid,
                    start_datetime = ther.eventdate,
                    concept_id = std.source_concept_id,
                    source_value = prod.gemscriptcode,
                    source_concept_id = ssource.source_concept_id,
                    type_concept_id = 32838,
                    start_date = ther.eventdate,
                    end_date = ther.eventdate.AddDays((double)(null != ther.numdays && 0 < ther.numdays && 365 > ther.numdays ? ther.numdays : (0 != ddecode.numdays ? ddecode.numdays : dmode.numdays))).ToString(),
                    sig = cdosage.dosage_text,
                });
            });
            Log.Info($"Finished StemTable #Therapy");
        }
    }
}
