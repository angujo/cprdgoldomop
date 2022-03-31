namespace CPRDGOLD.mappers
{
    internal class FactRelationship
    {
        public int domain_concept_id_1 { get; set; }
        public int domain_concept_id_2 { get; set; }
        public int fact_id_1 { get; set; }
        public int fact_id_2 { get; set; }
        public int relationship_concept_id { get; set; }
    }
}
