using System;

namespace CPRDGOLD.mappers
{
    internal class Note
    {
        public int encoding_concept_id { get; set; }
        public int language_concept_id { get; set; }
        public int note_class_concept_id { get; set; }
        public DateTime note_date { get; set; }
        public DateTime? note_datetime { get; set; }
    public long note_id { get; set; }
    public string note_source_value { get; set; }
    public string note_text { get; set; }
    public string note_title { get; set; }
    public int note_type_concept_id { get; set; }
    public int person_id { get; set; }
    public int? provider_id { get; set; }
    public int? visit_detail_id { get; set; }
    public long visit_occurrence_id { get; set; }
}
}
