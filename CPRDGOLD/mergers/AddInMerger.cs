using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRDGOLD.loaders;
using CPRDGOLD.models;
using DBMS;
using DBMS.models;
using SqlKata.Execution;
using Util;

namespace CPRDGOLD.mergers
{
    internal class AddInMerger : ChunkMerger<AddInMerger, AddIn>
    {

        protected AddInMerger(Chunk chunk) : base(chunk) { }
        private AddInBaseMerger baseMerger;

        public AddInMerger() { }

        protected override void LoadData() { }

        public static AddInMerger prepare(Chunk chunk)
        {
            var addM = new AddInMerger(chunk);
            addM.baseMerger = AddInBaseMerger.prepare(chunk);

            Log.Info("Starting AddIn Table");
            List<Action> unions = new List<Action>
            {
                ()=>addM.Union1(),
                ()=>addM.Union2(),
                ()=>addM.Union3(),
                ()=>addM.Union4(),
                ()=>addM.Union5(),
                ()=>addM.Union6(),
                ()=>addM.Union7(),
                ()=>addM.Union8(),
                ()=>addM.Union9(),
                ()=>addM.Union10(),
                ()=>addM.Union11(),
            };
            Parallel.ForEach(unions,Runner.ParallelOptions, union => union());
            Log.Info($"Total AddIn Table Data: {addM.data.Count}");
            if (0 == addM.data.Count) Log.Info("No AddIn Data for Source to standards");
            else
            {
                Log.Info("Looping AddIn Source to standards");
                Dictionary<string, SourceToStandard> sourceStds = new Dictionary<string, SourceToStandard>();
                DB.Source.RunFactory("source_to_standard", (query, schema_name) =>
                {
                    sourceStds = query.WhereIn("source_code", addM.data.Select(d => d.source_value).Distinct())
                    .Where("source_vocabulary_id", "JNJ_CPRD_ADD_ENTTYPE").WhereNull("target_invalid_reason").Where("target_standard_concept", "S")
                    .Select("source_code", "source_concept_id")
                    .Get<SourceToStandard>().ToDictionary(s => s.source_code, s => s);
                });
                foreach (AddIn dt in addM.data)
                {
                    if (!sourceStds.TryGetValue(dt.source_value, out SourceToStandard stStd)) continue;
                    dt.st_source_concept_id = stStd.source_concept_id;
                    dt.st_target_concept_id = stStd.target_concept_id;
                }
            }
            Log.Info("Finished Looping AddIn Source to standards");

            Log.Info("Finished AddIn Table");
            return addM;
        }

        private AddIn preloadBase(AddInBase addInBase)
        {
            return new AddIn
            {
                patid = addInBase.patid,
                eventdate = addInBase.eventdate,
                consid = addInBase.consid,
                constype = (short)addInBase.constype,
                staffid = addInBase.staffid,
                enttype = (short)addInBase.enttype,
                category = addInBase.category,
                description = addInBase.description,
                data_fields = (short)addInBase.data_fields,
                chunk_identifier = addInBase.chunk_identifier,
            };
        }

        private void Union1()
        {
            baseMerger.LoopUnions(1, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data1_lkup, addInBase.data1) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data1) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data1) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data                  = addInBase.e_data1;
               addIn.value_as_number       = Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup) ? null : addInBase.data1;
               addIn.value_as_string       = addInBase.data1_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data1_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date         = addInBase.data1_lkup == Consts.DATE_FORMAT ? addInBase.data1 : null;
               addIn.unit_source_value     = new[] { 13, 488 }.Contains(addInBase.enttype) ? "kg" : (476 == addInBase.enttype ? "cm" : (new[] { 119, 61, 60, 120 }.Contains(addInBase.enttype) ? "week" : (14 == addInBase.enttype ? "m" : null)));
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value          = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data1;
               Add(addIn);
           });
        }

        private void Union2()
        {
            baseMerger.LoopUnions(2, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data2_lkup, addInBase.data2) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data2) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data2) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data2;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data2_lkup) ? null : addInBase.data2;
               addIn.value_as_string = addInBase.data2_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data2_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data2_lkup == Consts.DATE_FORMAT ? addInBase.data2 : null;
               addIn.unit_source_value = 52 == addInBase.enttype ? "hour" : (69 == addInBase.enttype ? "week" : (150 == addInBase.enttype ? "day" : null));
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data2;
               Add(addIn);
           });
        }

        private void Union3()
        {
            baseMerger.LoopUnions(3, addInBase =>
            {
                Lookup lu = LookupLoader.ByNameCode(addInBase.data3_lkup, addInBase.data3) ?? new Lookup();
                Medical med = MedicalLoader.ByMedcode(addInBase.data3) ?? new Medical();
                Product product = ProductLoader.ByProdcode(addInBase.data3) ?? new Product();

                AddIn addIn = preloadBase(addInBase);
                addIn.data = addInBase.e_data3;
                addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data3_lkup) ? null : addInBase.data3;
                addIn.value_as_string = addInBase.data3_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data3_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
                addIn.value_as_date = addInBase.data3_lkup == Consts.DATE_FORMAT ? addInBase.data3 : null;
                addIn.read_code_description = med.desc;
                addIn.gemscript_description = product.productname;
                addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data3;
                Add(addIn);
            });
        }

        private void Union4()
        {
            baseMerger.LoopUnions(4, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data4_lkup, addInBase.data4) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data4) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data4) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data4;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data4_lkup) ? null : addInBase.data4;
               addIn.value_as_string = addInBase.data4_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data4_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data4_lkup == Consts.DATE_FORMAT ? addInBase.data4 : null;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data4;
               Add(addIn);
           });
        }

        private void Union5()
        {
            baseMerger.LoopUnions(5, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data5_lkup, addInBase.data5) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data5) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data5) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data5;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data5_lkup) ? null : addInBase.data5;
               addIn.value_as_string = addInBase.data5_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data5_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data5_lkup == Consts.DATE_FORMAT ? addInBase.data5 : null;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data5;
               Add(addIn);
           });
        }

        private void Union6()
        {
            baseMerger.LoopUnions(6, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data6_lkup, addInBase.data6) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data6) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data6) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data6;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data6_lkup) ? null : addInBase.data6;
               addIn.value_as_string = addInBase.data6_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data6_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data6_lkup == Consts.DATE_FORMAT ? addInBase.data6 : null;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data6;
               Add(addIn);
           });
        }

        private void Union7()
        {
            baseMerger.LoopUnions(7, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data7_lkup, addInBase.data7) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data7) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data7) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data7;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data7_lkup) ? null : addInBase.data7;
               addIn.value_as_string = addInBase.data7_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data6_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data7_lkup == Consts.DATE_FORMAT ? addInBase.data7 : null;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data7;
               Add(addIn);
           });
        }

        private void Union8()
        {
            baseMerger.LoopUnions(8, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data1_lkup, addInBase.data1) ?? new Lookup();
               Lookup lu2 = LookupLoader.ByNameCode(addInBase.data2_lkup, addInBase.data2) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data1) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data1) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data1;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup) ? null : addInBase.data1;
               addIn.value_as_string = addInBase.data1_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data1_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data1_lkup == Consts.DATE_FORMAT ? addInBase.data1 : null;
               addIn.unit_source_value = lu2.text;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data1;
               Add(addIn);
           });
        }

        private void Union9()
        {
            baseMerger.LoopUnions(9, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data3_lkup, addInBase.data3) ?? new Lookup();
               Lookup lu2 = LookupLoader.ByNameCode(addInBase.data4_lkup, addInBase.data4) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data3) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data3) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data3;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data3_lkup) ? null : addInBase.data3;
               addIn.value_as_string = addInBase.data3_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data3_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data3_lkup == Consts.DATE_FORMAT ? addInBase.data3 : null;
               addIn.unit_source_value = lu2.text;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data3;
               Add(addIn);
           });
        }

        private void Union10()
        {
            baseMerger.LoopUnions(10, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data5_lkup, addInBase.data5) ?? new Lookup();
               Lookup lu2 = LookupLoader.ByNameCode(addInBase.data6_lkup, addInBase.data6) ?? new Lookup();
               Medical med = MedicalLoader.ByMedcode(addInBase.data5) ?? new Medical();
               Product product = ProductLoader.ByProdcode(addInBase.data5) ?? new Product();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = addInBase.e_data5;
               addIn.value_as_number = Consts.MED_PRD_DICT.Contains(addInBase.data5_lkup) ? null : addInBase.data5;
               addIn.value_as_string = addInBase.data5_lkup == Consts.MED_DICT ? med.read_code : (addInBase.data5_lkup == Consts.PRD_DICT ? product.gemscriptcode : lu.text);
               addIn.value_as_date = addInBase.data5_lkup == Consts.DATE_FORMAT ? addInBase.data5 : null;
               addIn.unit_source_value = lu2.text;
               addIn.read_code_description = med.desc;
               addIn.gemscript_description = product.productname;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + addInBase.e_data5;
               Add(addIn);
           });
        }

        private void Union11()
        {
            baseMerger.LoopUnions(11, addInBase =>
           {
               Lookup lu = LookupLoader.ByNameCode(addInBase.data5_lkup, addInBase.data5) ?? new Lookup();
               ScoreMethod scoreMethod = ScoreMethodLoader.ByCode(addInBase.data5) ?? new ScoreMethod();

               AddIn addIn = preloadBase(addInBase);
               addIn.data = scoreMethod.scoringmethod;
               addIn.value_as_number = addInBase.data1;
               addIn.value_as_date = addInBase.data1_lkup == Consts.DATE_FORMAT ? addInBase.data1 : null;
               addIn.source_value = addInBase.enttype + "-" + addInBase.category + "-" + addInBase.description + "-" + scoreMethod.scoringmethod;
               Add(addIn);
           });
        }
    }
}
