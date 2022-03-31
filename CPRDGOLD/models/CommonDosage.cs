namespace CPRDGOLD.models
{
    public class CommonDosage
    {
        public long id { get; set; }
        public string dosageid { get; set; }
        public string dosage_text { get; set; }
        public decimal? daily_dose { get; set; }
        public decimal? dose_number { get; set; }
        public string dose_unit { get; set; }
        public decimal? dose_frequency { get; set; }
        public decimal? dose_interval { get; set; }
        public short choice_of_dose { get; set; }
        public short dose_max_average { get; set; }
        public short change_dose { get; set; }
        public decimal? dose_duration { get; set; }
    }
}
