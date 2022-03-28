using CPRDGOLD.loaders;
using CPRDGOLD.models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mergers
{
    internal class AddInBaseMerger : ChunkMerger<AddInBaseMerger, AddInBase>
    {


        private ConcurrentDictionary<int, List<AddInBase>> unions = new ConcurrentDictionary<int, List<AddInBase>>();
        protected AddInBaseMerger(Chunk chunk) : base(chunk) { chunk.AddCleaner(() => unions.Clear()); }
        // string[] MED_PRD_DICT = new string[] { MED_DICT, PRD_DICT };
        public AddInBaseMerger() { }
        protected override void LoadData() { }

        public static void prepare(Chunk chunk)
        {
            ClinicalLoader.Prepare(chunk);
            //  if (0 < data.Count) return;
            Log.Info("Starting AddInBase Loader!");
            for (int i = 0; i < 7; i++) GetMe(chunk).unions[i + 1] = new List<AddInBase>();
            AdditionalLoader.LoopAll(chunk, addt =>
            {
                Clinical cl = ClinicalLoader.ByPatientAdId(chunk, addt.adid, addt.patid);
                if (null == cl || null == cl.eventdate) return;
                Entity entity = EntityLoader.ByType(addt.enttype) ?? new Entity();
                AddInBase addInBase = new AddInBase
                {
                    patid = addt.patid,
                    adid = addt.adid,
                    enttype = addt.enttype,
                    data1 = addt.data1,
                    data2 = addt.data2,
                    data3 = addt.data3,
                    data4 = addt.data4,
                    data5 = addt.data5,
                    data6 = addt.data6,
                    data7 = addt.data7,
                    eventdate = cl.eventdate,
                    constype = cl.constype,
                    consid = cl.consid,
                    staffid = cl.staffid,
                    data_fields = entity.data_fields,
                    category = entity.category,
                    description = entity.description,
                    e_data1 = entity.data1,
                    e_data2 = entity.data2,
                    e_data3 = entity.data3,
                    e_data4 = entity.data4,
                    e_data5 = entity.data5,
                    e_data6 = entity.data6,
                    e_data7 = entity.data7,
                    data1_lkup = entity.data1_lkup,
                    data2_lkup = entity.data2_lkup,
                    data3_lkup = entity.data3_lkup,
                    data4_lkup = entity.data4_lkup,
                    data5_lkup = entity.data5_lkup,
                    data6_lkup = entity.data6_lkup,
                    data7_lkup = entity.data7_lkup,
                };
                //  Add(addInBase);

                List<Action> actions = new List<Action> {
                    () => GetMe(chunk).ForUnion1(addInBase),
                    () => GetMe(chunk).ForUnion2(addInBase),
                    () => GetMe(chunk).ForUnion3(addInBase),
                    () => GetMe(chunk).ForUnion4(addInBase),
                    () => GetMe(chunk).ForUnion5(addInBase),
                    () => GetMe(chunk).ForUnion6(addInBase),
                    () => GetMe(chunk).ForUnion7(addInBase),
                    () => GetMe(chunk).ForUnion8(addInBase),
                    () => GetMe(chunk).ForUnion9(addInBase),
                    () => GetMe(chunk).ForUnion10(addInBase),
                    () => GetMe(chunk).ForUnion11(addInBase),
                 };
                Parallel.ForEach(actions, action => action());
            });
            Log.Info("Finished AddInBase Loader!");
        }

        public static void LoopUnion(Chunk chunk, int union, Action<AddInBase> abAct)
        {
            if (!GetMe(chunk).unions.ContainsKey(union))
            {
                Log.Info($"Union {union} Was not Loaded. Skipped!");
                return;
            }
            Log.Info($"Started Loading Union #{union}!");
            Parallel.ForEach(GetMe(chunk).unions[union], abAct);
            // foreach (var item in GetMe(chunk).unions[union]) abAct(item);
            Log.Info($"Finished Loading Union #{union}!");
        }

        private void ForUnion1(AddInBase addInBase)
        {
            int[] types = new int[] { 72, 116, 372, 78 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 0 || !Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup)) return;
            unions[1].Add(addInBase);
        }

        private void ForUnion2(AddInBase addInBase)
        {
            int[] types = new int[] { 72, 116, 78, 60, 119, 120 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 1 || !Consts.MED_PRD_DICT.Contains(addInBase.data2_lkup)) return;
            unions[2].Add(addInBase);
        }

        private void ForUnion3(AddInBase addInBase)
        {
            int[] types = new int[] { 372, 78, 126 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 2 || !Consts.MED_PRD_DICT.Contains(addInBase.data3_lkup)) return;
            unions[3].Add(addInBase);
        }

        private void ForUnion4(AddInBase addInBase)
        {
            int[] types = new int[] { 372, 78, 126 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 3 || !Consts.MED_PRD_DICT.Contains(addInBase.data4_lkup)) return;
            unions[4].Add(addInBase);
        }

        private void ForUnion5(AddInBase addInBase)
        {
            int[] types = new int[] { 78 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 4 || !Consts.MED_PRD_DICT.Contains(addInBase.data5_lkup)) return;
            unions[5].Add(addInBase);
        }

        private void ForUnion6(AddInBase addInBase)
        {
            int[] types = new int[] { 78 };
            if (types.Contains(addInBase.enttype) || addInBase.data_fields <= 5 || !Consts.MED_PRD_DICT.Contains(addInBase.data6_lkup)) return;
            unions[6].Add(addInBase);
        }

        private void ForUnion7(AddInBase addInBase)
        {
            if (addInBase.data_fields <= 6 || !Consts.MED_PRD_DICT.Contains(addInBase.data7_lkup)) return;
            unions[7].Add(addInBase);
        }

        private void ForUnion8(AddInBase addInBase)
        {
            int[] types = new int[] { 72, 116, 78 };
            if (!types.Contains(addInBase.enttype) || !Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup)) return;
            unions[8].Add(addInBase);
        }

        private void ForUnion9(AddInBase addInBase)
        {
            int[] types = new int[] { 126, 78 };
            if (!types.Contains(addInBase.enttype) || !Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup)) return;
            unions[9].Add(addInBase);
        }

        private void ForUnion10(AddInBase addInBase)
        {
            int[] types = new int[] { 78 };
            if (!types.Contains(addInBase.enttype) || !Consts.MED_PRD_DICT.Contains(addInBase.data1_lkup)) return;
            unions[10].Add(addInBase);
        }

        private void ForUnion11(AddInBase addInBase)
        {
            int[] types = new int[] { 372 };
            if (!types.Contains(addInBase.enttype)) return;
            unions[1].Add(addInBase);
        }
    }
}
