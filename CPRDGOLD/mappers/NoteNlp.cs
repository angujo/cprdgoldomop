using System;

namespace CPRDGOLD.mappers
{
    internal class NoteNlp
    {
        public string lexical_variant { get; set; }
        public DateTime nlp_date { get; set; }
        public DateTime? nlp_datetime { get; set; }
        public string nlp_system { get; set; }
        public int note_id { get; set; }
        public int? note_nlp_concept_id { get; set; }
        public long note_nlp_id { get; set; }
        public int? note_nlp_source_concept_id { get; set; }
        public string offset { get; set; }
        public int? section_concept_id { get; set; }
        public string snippet { get; set; }
        public string term_exists { get; set; }
        public string term_modifiers { get; set; }
        public string term_temporal { get; set; }
    }
}
