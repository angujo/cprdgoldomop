ALTER TABLE {sc}.drug_exposure DROP COLUMN IF EXISTS drug_exposure_id;
ALTER TABLE {sc}.drug_exposure ADD drug_exposure_id serial8 NOT NULL;
CREATE INDEX idx_drug_exposure_concept_id ON {sc}.drug_exposure USING btree (drug_concept_id);
CREATE INDEX idx_drug_exposure_person_id ON {sc}.drug_exposure USING btree (person_id);
CREATE INDEX idx_drug_exposure_visit_id ON {sc}.drug_exposure USING btree (visit_occurrence_id);