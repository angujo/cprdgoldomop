ALTER TABLE {sc}.measurement DROP COLUMN IF EXISTS measurement_id;
ALTER TABLE {sc}.measurement ADD measurement_id serial8 NOT NULL;
CREATE INDEX idx_measurement_concept_id ON {sc}.measurement USING btree (measurement_concept_id);
CREATE INDEX idx_measurement_person_id ON {sc}.measurement USING btree (person_id);
CREATE INDEX idx_measurement_visit_id ON {sc}.measurement USING btree (visit_occurrence_id);