CREATE INDEX idx_dose_era_concept_id ON {sc}.dose_era USING btree (drug_concept_id);
CREATE INDEX idx_dose_era_person_id ON {sc}.dose_era USING btree (person_id);
CREATE UNIQUE INDEX xpk_dose_era ON {sc}.dose_era USING btree (dose_era_id);