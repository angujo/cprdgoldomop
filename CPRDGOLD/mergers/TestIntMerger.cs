using CPRDGOLD.loaders;
using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.mergers
{
    internal class TestIntMerger : ChunkMerger<TestIntMerger, TestInt>
    {
        protected TestIntMerger(Chunk chunk) : base(chunk)
        {
        }

        public TestIntMerger()
        {
        }

        protected override void LoadData()
        {
            //  string ename;// = EntityLoader.dataFieldFilter(new int[] { 7, 8, 4 });
            Entity entity;
            chunk.GetLoader<TestLoader>(ChunkLoadType.TEST).LoopAllData(test =>
            {
                var lu = LookupLoader.ByCodeType(test.data1, new long[] {85, 56});
                if (default == lu || default == lu.lookup_type_id || 0 == lu.lookup_type_id) return;
                entity = 85 == lu.lookup_type_id
                    ? EntityLoader.ByDataFieldType(new[] {7, 8}, test.enttype)
                    : EntityLoader.ByDataFieldType(4, test.enttype);
                if (entity == null) return;
                var ti = new TestInt
                {
                    conc_domain_id       = test.conc_domain_id,
                    patid                = test.patid,
                    eventdate            = test.eventdate,
                    consid               = test.consid,
                    staffid              = test.staffid,
                    read_code            = test.med_read_code,
                    medcode              = test.medcode,
                    read_description     = test.read_description,
                    map_value            = entity.enttype + "-" + entity.description,
                    enttype              = test.enttype,
                    enttype_desc         = entity.description,
                    data_fields          = entity.data_fields,
                    Operator             = "",
                    value_as_number      = null,
                    unit                 = "",
                    value_as_concept_id  = "0" != test.data1 ? lu.text : "",
                    range_low            = test.data2,
                    range_high           = test.data3,
                    ss_source_concept_id = test.ss_source_concept_id,
                    st_source_concept_id = test.st_source_concept_id,
                    st_target_concept_id = test.st_target_concept_id,
                    ss_target_concept_id = test.ss_target_concept_id,
                    chunk_identifier     = test.chunk_identifier
                };

                if (56 == lu.lookup_type_id)
                {
                    var lu2 = LookupLoader.ByCodeType(test.data3, 83);
                    var lu3 = LookupLoader.ByCodeType(test.data4, 85);
                    ti.value_as_concept_id = "0" != test.data1 ? lu.text : "";
                    ti.value_as_number     = test.data2;
                    ti.Operator            = test.data1 != "0" ? lu.text : "";
                    ti.unit = "0" != test.data1
                        ? lu2.text
                        : (284 == test.enttype && test.data2 != null && "0" != test.data2 ? "week" : null);
                    ti.value_as_concept_id = "0" != test.data4 ? lu3.text : null;
                    ti.range_high          = test.data6;
                    ti.range_low           = test.data5;
                }

                Add(ti);
            });
        }
    }
}