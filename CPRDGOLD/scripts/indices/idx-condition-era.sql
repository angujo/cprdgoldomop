ALTER TABLE {sc}.condition_era ADD condition_era_id serial8 NOT NULL;
CREATE INDEX idx_condition_era_concept_id ON {sc}.condition_era USING btree (condition_concept_id);
CREATE INDEX idx_condition_era_person_id ON {sc}.condition_era USING btree (person_id);