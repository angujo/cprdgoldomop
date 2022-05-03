using CPRDGOLD.loaders;
using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.mergers
{
    internal class TestIntMerger : ChunkMerger<TestIntMerger, TestInt>
    {
        protected TestIntMerger(Chunk chunk) : base(chunk) { }
        public TestIntMerger() : base() { }

        protected override void LoadData()
        {
            //  string ename;// = EntityLoader.dataFieldFilter(new int[] { 7, 8, 4 });
            Entity entity;
            chunk.GetLoader<TestLoader>(ChunkLoadType.TEST).LoopAllData(test =>
             {
                 Lookup lu = LookupLoader.ByCodeType(test.data1, new long[] { 85, 56 });
                 if (default == lu || default == lu.lookup_type_id || 0 == lu.lookup_type_id) return;
                 entity = 85 == lu.lookup_type_id ? EntityLoader.ByDataFieldType(new int[] { 7, 8 }, test.enttype) : EntityLoader.ByDataFieldType(4, test.enttype);
                 if (null == entity || default == entity) return;
                 TestInt ti = new TestInt();
                 ti.conc_domain_id = test.conc_domain_id;
                 ti.patid = test.patid;
                 ti.eventdate = test.eventdate;
                 ti.consid = test.consid;
                 ti.staffid = test.staffid;
                 ti.read_code = test.med_read_code;
                 ti.medcode = test.medcode;
                 ti.read_description = test.read_description;
                 ti.map_value = entity.enttype + "-" + entity.description;
                 ti.enttype = test.enttype;
                 ti.enttype_desc = entity.description;
                 ti.data_fields = entity.data_fields;
                 ti.Operator = "";
                 ti.value_as_number = null;
                 ti.unit = "";
                 ti.value_as_concept_id = "0" != test.data1 ? lu.text : "";
                 ti.range_low = test.data2;
                 ti.range_high = test.data3;
                 ti.ss_source_concept_id = test.ss_source_concept_id;
                 ti.st_source_concept_id = test.st_source_concept_id;
                 ti.st_target_concept_id = test.st_target_concept_id;
                 ti.ss_target_concept_id = test.ss_target_concept_id;
                 ti.chunk_identifier = test.chunk_identifier;

                 if (56 == lu.lookup_type_id)
                 {
                     Lookup lu2 = LookupLoader.ByCodeType(test.data3, 83);
                     Lookup lu3 = LookupLoader.ByCodeType(test.data4, 85);
                     ti.value_as_concept_id = "0" != test.data1 ? lu.text : "";
                     ti.value_as_number = test.data2;
                     ti.unit = "0" != test.data1 ? lu2.text : (284 == test.enttype && test.data2 != null && "0" != test.data2 ? "week" : null);
                     ti.value_as_concept_id = "0" != test.data4 ? lu3.text : null;
                     ti.range_high = test.data6;
                     ti.range_low = test.data5;
                 }
                 Add(ti);
             });
        }
    }
}
