﻿using CPRDGOLD.loaders;
using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

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
            TestLoader.LoopAll(chunk, test =>
            {
                Lookup lu = LookupLoader.ByCodeType(test.data1, new long[] { 85, 56 });
                if (0 == lu.lookup_type_id ||
                null == (entity = (85 == lu.lookup_type_id ? EntityLoader.ByDataFieldType(new int[] { 7, 8 }, test.enttype) : EntityLoader.ByDataFieldType(4, test.enttype)))) return;
                TestInt ti = new TestInt
                {
                    patid = test.patid,
                    eventdate = test.eventdate,
                    consid = test.consid,
                    staffid = test.staffid,
                    read_code = test.med_read_code,
                    medcode = test.medcode,
                    read_description = test.read_description,
                    map_value = entity.enttype + "-" + entity.description,
                    enttype = test.enttype,
                    enttype_desc = entity.description,
                    data_fields = entity.data_fields,
                    Operator = "",
                    value_as_number = null,
                    unit = "",
                    value_as_concept_id = "0" != test.data1 ? lu.text : "",
                    range_low = test.data2,
                    range_high = test.data3,
                    ss_source_concept_id = test.ss_source_concept_id,
                    st_source_concept_id = test.st_source_concept_id
                };
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
