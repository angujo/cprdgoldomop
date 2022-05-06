CREATE INDEX idx_fact_relationship_id_1 ON {sc}.fact_relationship USING btree (domain_concept_id_1);
CREATE INDEX idx_fact_relationship_id_2 ON {sc}.fact_relationship USING btree (domain_concept_id_2);
CREATE INDEX idx_fact_relationship_id_3 ON {sc}.fact_relationship USING btree (relationship_concept_id);