using DBMS;
using DBMS.models;
using SqlKata;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class ChunkLoader<T, C> : Loader<T, C> where T : new()
    {
        private static ConcurrentDictionary<int, T> _instances = new ConcurrentDictionary<int, T>();
        protected Chunk chunk { get; set; }
        protected string chunkColumn = "patid";
        public ChunkLoader(string table_name, Chunk chunk) : base(DB.Source, table_name) { this.chunk = chunk; chunk.AddCleaner(() => this.Clean()); }
        public ChunkLoader(string table_name) : base(DB.Source, table_name) { }

        public Chunk GetChunk()
        {
            return chunk;
        }


        public void CustomizeQuery(Query query, string schema_name)
        {
            switch (table_name)
            {
                case "consultation":
                    // When Loading visit_detail, the following merge is irrelevant 
                    /* DBMSSystem db = (DBMSSystem)chunk.dbms;
                     var withChunk = new Query($"{db.schema.SchemaName}.{chunk.tableName}")
                         .Where("ordinal", chunk.ordinal).Select("patient_id");
                     var clinical = new Query("chunks")
                         .Join($"{schema_name}.clinical", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                         .Select("patid", "eventdate", "consid", "staffid");
                     var referral = new Query("chunks")
                         .Join($"{schema_name}.referral", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                         .Select("patid", "eventdate", "consid", "staffid");
                     var test = new Query("chunks")
                         .Join($"{schema_name}.test", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                         .Select("patid", "eventdate", "consid", "staffid");
                     var immunisation = new Query("chunks")
                         .Join($"{schema_name}.immunisation", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                         .Select("patid", "eventdate", "consid", "staffid");
                     var therapy = new Query("chunks")
                         .Join($"{schema_name}.therapy", j => j.On("patient_id", "patid").WhereNotNull("eventdate"))
                         .Select("patid", "eventdate", "consid", "staffid");
                     query.With("chunks", withChunk)
                         .Join(clinical.UnionAll(referral).UnionAll(test).UnionAll(immunisation).UnionAll(therapy).As("u"),
                         j => j.WhereRaw("consultation.patid=u.patid AND consultation.consid = u.consid AND consultation.eventdate = u.eventdate"));*/
                    break;
                case "patient":
                    if ("ActivePatientLoader" == typeof(T).Name)
                        query.WhereRaw("accept = 1 AND gender::int IN (1,2) AND (case when 4 > char_length(yob::varchar) then 1800+yob else yob end) > 1875 AND (deathdate IS NULL OR deathdate >= crd)");
                    else
                        query.Join($"{schema_name}.practice", j => j.WhereRaw("RIGHT(patient.patid::varchar,5)::numeric = practice.pracid"))
                            .SelectRaw("greatest(patient.frd,practice.uts) AS op_start_date, least(patient.tod,practice.lcd, patient.crd) AS op_end_date, 32880 AS pt_concept_id");
                    break;
                case "clinical":
                    query.Join($"{schema_name}.medical", "medical.medcode", "clinical.medcode")
                        .Join($"{schema_name}.source_to_standard",
                            j => j.On("source_to_standard.source_code", "medical.read_code")
                            .WhereNull("source_to_standard.target_invalid_reason")
                            .Where("source_to_standard.target_standard_concept", "S")
                            .Where("source_to_standard.source_vocabulary_id", "Read"))
                        .LeftJoin($"{schema_name}.source_to_source",
                            j => j.On("source_to_source.source_code", "medical.read_code")
                            .Where("source_to_source.source_vocabulary_id", "Read"))
                        .SelectRaw("source_to_standard.source_concept_id as st_source_concept_id," +
                        " source_to_source.source_concept_id as ss_source_concept_id, medical.read_code AS med_read_code");
                    break;
                case "immunisation":
                    query.Join($"{schema_name}.medical", "medical.medcode", "immunisation.medcode")
                        .Join($"{schema_name}.source_to_standard",
                            j => j.On("source_to_standard.source_code", "medical.read_code")
                            .WhereNull("source_to_standard.target_invalid_reason")
                            .Where("source_to_standard.target_standard_concept", "S")
                            .Where("source_to_standard.source_vocabulary_id", "Read"))
                        .LeftJoin($"{schema_name}.source_to_source",
                            j => j.On("source_to_source.source_code", "medical.read_code")
                            .Where("source_to_source.source_vocabulary_id", "Read"))
                        .SelectRaw("source_to_standard.source_concept_id as st_source_concept_id," +
                        " source_to_source.source_concept_id as ss_source_concept_id, medical.read_code AS med_read_code");
                    break;
                case "referral":
                    query.Join($"{schema_name}.medical", "medical.medcode", "referral.medcode")
                        .Join($"{schema_name}.source_to_standard",
                            j => j.On("source_to_standard.source_code", "medical.read_code")
                            .WhereNull("source_to_standard.target_invalid_reason")
                            .Where("source_to_standard.target_standard_concept", "S")
                            .Where("source_to_standard.source_vocabulary_id", "Read"))
                        .LeftJoin($"{schema_name}.source_to_source",
                            j => j.On("source_to_source.source_code", "medical.read_code")
                            .Where("source_to_source.source_vocabulary_id", "Read"))
                        .SelectRaw("source_to_standard.source_concept_id as st_source_concept_id," +
                        " source_to_source.source_concept_id as ss_source_concept_id, medical.read_code AS med_read_code");
                    break;
                case "test":
                    query.Join($"{schema_name}.medical", "medical.medcode", "test.medcode")
                        .Join($"{schema_name}.source_to_standard",
                            j => j.On("source_to_standard.source_code", "medical.read_code")
                            .WhereNull("source_to_standard.target_invalid_reason")
                            .Where("source_to_standard.target_standard_concept", "S")
                            .Where("source_to_standard.source_vocabulary_id", "JNJ_CPRD_TEST_ENT"))
                        .LeftJoin($"{schema_name}.source_to_source",
                            j => j.On("source_to_source.source_code", "medical.read_code")
                            .Where("source_to_source.source_vocabulary_id", "Read"))
                        .SelectRaw("source_to_standard.source_concept_id as st_source_concept_id," +
                        " source_to_source.source_concept_id as ss_source_concept_id, medical.read_code AS med_read_code, medical.desc as read_description");
                    break;
                case "therapy":
                    query.Join($"{schema_name}.product", "product.prodcode", "therapy.prodcode")
                        .Join($"{schema_name}.source_to_standard",
                            j => j.On("source_to_standard.source_code", "product.gemscriptcode")
                            .WhereNull("source_to_standard.target_invalid_reason")
                            .Where("source_to_standard.target_standard_concept", "S")
                            .Where("source_to_standard.source_vocabulary_id", "gemscript"))
                        .LeftJoin($"{schema_name}.source_to_source",
                            j => j.On("source_to_source.source_code", "product.gemscriptcode")
                            .Where("source_to_source.source_vocabulary_id", "gemscript"))
                        .WhereRaw("therapy.eventdate between source_to_standard.source_valid_start_date and source_to_standard.source_valid_end_date")
                        .SelectRaw("product.gemscriptcode AS prod_gemscriptcode, source_to_standard.source_concept_id as st_source_concept_id," +
                        " source_to_source.source_concept_id as ss_source_concept_id");
                    break;
            }
        }

        protected static T GetMe(Chunk chunk)
        {
            if (_instances.ContainsKey(chunk.ordinal)) return _instances[chunk.ordinal];
            _instances[chunk.ordinal] = new T();// (T)Activator.CreateInstance(typeof(T), new object[] { chunk });// new T(chunk);
            ((ChunkLoader<T, C>)(object)_instances[chunk.ordinal]).chunk = chunk;
            Log.Info($"Starting Chunk Data Load #ChunkLoader [{typeof(T).Name}]");
            ((ChunkLoader<T, C>)(object)_instances[chunk.ordinal]).LoadData();
            Log.Info($"Finished Chunk Data Load #ChunkLoader [{typeof(T).Name}]");
            return _instances[chunk.ordinal];
        }

        public static void LoopAll(Chunk chunk, Action<C> looper)
        {
            Log.Info($"Starting Chunk LoopAll #ChunkLoader [{typeof(T).Name}]");
            var m = (ChunkLoader<T, C>)(object)GetMe(chunk);
            Log.Info($"Total Data Chunk to LoopAll [{m.dataset.Count}] [{typeof(T).Name}]");
            foreach (C c in m.dataset)
            {
                looper(c);
            }
            Log.Info($"Finished Chunk LoopAll #ChunkLoader [{typeof(T).Name}]");
        }

        public static List<C> GetData(Chunk chunk) => ((ChunkLoader<T, C>)(object)GetMe(chunk)).dataset;

        public static new List<C> GetData() => throw new NotImplementedException();
        protected static new T GetMe() => throw new NotImplementedException();
        public static new T LoopAll(Action<C> looper) { throw new NotImplementedException(); }

        #region ChunkData

        protected static C ChunkValue(Chunk chunk, params string[] keys) => ChunkValue(new string[][] { keys }, chunk);
        protected static C ChunkValue(IEnumerable<string[]> keys, Chunk chunk) => ChunkValue(keys.ToArray(), chunk);
        protected static C ChunkValue(string[][] keys, Chunk chunk) => ((ChunkLoader<T, C>)(object)GetMe(chunk)).IChunkValue(keys);

        #region thrown Parent ChunkData
        protected static new C ChunkValue(params string[] keys) => throw new NotImplementedException();
        protected static new C ChunkValue(IEnumerable<string[]> keys) => throw new NotImplementedException();
        protected static new C ChunkValue(string[][] keys) => throw new NotImplementedException();

        #endregion

        #endregion
    }
}
