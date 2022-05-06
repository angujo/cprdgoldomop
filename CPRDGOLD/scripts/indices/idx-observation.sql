ALTER TABLE {sc}.observation DROP COLUMN IF EXISTS observation_id;
ALTER TABLE {sc}.observation ADD observation_id serial8 NOT NULL;
CREATE INDEX idx_observation_concept_id ON {sc}.observation USING btree (observation_concept_id);
CREATE INDEX idx_observation_person_id ON {sc}.observation USING btree (person_id);
CREATE INDEX idx_observation_visit_id ON {sc}.observation USING btree (visit_occurrence_id);