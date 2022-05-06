CREATE UNIQUE INDEX idx_concept_class_class_id ON {vs}.concept_class USING btree (concept_class_id);
CREATE UNIQUE INDEX xpk_concept_class ON {vs}.concept_class USING btree (concept_class_id);