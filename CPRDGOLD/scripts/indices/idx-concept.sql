CREATE INDEX idx_concept_class_id ON {sc}.concept USING btree (concept_class_id);
CREATE INDEX idx_concept_code ON {sc}.concept USING btree (concept_code);
CREATE UNIQUE INDEX idx_concept_concept_id ON {sc}.concept USING btree (concept_id);
CREATE INDEX idx_concept_domain_id ON {sc}.concept USING btree (domain_id);
CREATE INDEX idx_concept_vocabulary_id ON {sc}.concept USING btree (vocabulary_id);
CREATE UNIQUE INDEX xpk_concept ON {sc}.concept USING btree (concept_id);