CREATE INDEX idx_concept_relationship_id_1 ON {vs}.concept_relationship USING btree (concept_id_1);
CREATE INDEX idx_concept_relationship_id_2 ON {vs}.concept_relationship USING btree (concept_id_2);
CREATE INDEX idx_concept_relationship_id_3 ON {vs}.concept_relationship USING btree (relationship_id);
CREATE UNIQUE INDEX xpk_concept_relationship ON {vs}.concept_relationship USING btree (concept_id_1, concept_id_2, relationship_id);