ALTER TABLE {sc}.drug_era ADD CONSTRAINT drug_era_pk PRIMARY KEY (drug_era_id);
CREATE INDEX idx_drug_era_concept_id ON {sc}.drug_era USING btree (drug_concept_id);
CREATE INDEX idx_drug_era_person_id ON {sc}.drug_era USING btree (person_id);