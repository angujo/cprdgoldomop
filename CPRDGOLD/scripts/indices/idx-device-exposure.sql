ALTER TABLE {sc}.device_exposure DROP COLUMN IF EXISTS device_exposure_id;
ALTER TABLE {sc}.device_exposure ADD device_exposure_id serial8 NOT NULL;
CREATE INDEX idx_device_concept_id ON {sc}.device_exposure USING btree (device_concept_id);
CREATE INDEX idx_device_person_id ON {sc}.device_exposure USING btree (person_id);
CREATE INDEX idx_device_visit_id ON {sc}.device_exposure USING btree (visit_occurrence_id);