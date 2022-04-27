using System;

namespace CPRDGOLD.mergers
{
    internal class AddInBase
    {
        public long patid { get; set; }
        public int adid { get; set; }
        public int enttype { get; set; }
        public string data1 { get; set; }
        public string data2 { get; set; }
        public string data3 { get; set; }
        public string data4 { get; set; }
        public string data5 { get; set; }
        public string data6 { get; set; }
        public string data7 { get; set; }
        public DateTime eventdate { get; set; }
        public int constype { get; set; }
        public int consid { get; set; }
        public long staffid { get; set; }
        public int data_fields { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string e_data1 { get; set; }
        public string e_data2 { get; set; }
        public string e_data3 { get; set; }
        public string e_data4 { get; set; }
        public string e_data5 { get; set; }
        public string e_data6 { get; set; }
        public string e_data7 { get; set; }
        public string data1_lkup { get; set; }
        public string data2_lkup { get; set; }
        public string data3_lkup { get; set; }
        public string data4_lkup { get; set; }
        public string data5_lkup { get; set; }
        public string data6_lkup { get; set; }
        public string data7_lkup { get; set; }
        public long chunk_identifier { get; set; }
    }
}
