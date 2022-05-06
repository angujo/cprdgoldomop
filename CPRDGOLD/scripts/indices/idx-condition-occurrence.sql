ALTER TABLE {sc}.condition_occurrence DROP COLUMN IF EXISTS condition_occurrence_id;
ALTER TABLE {sc}.condition_occurrence ADD condition_occurrence_id serial8 NOT NULL;
CREATE INDEX idx_condition_concept_id ON {sc}.condition_occurrence USING btree (condition_concept_id);
CREATE INDEX idx_condition_person_id ON {sc}.condition_occurrence USING btree (person_id);
CREATE INDEX idx_condition_visit_id ON {sc}.condition_occurrence USING btree (visit_occurrence_id);