ALTER TABLE {sc}.specimen DROP COLUMN IF EXISTS specimen_id;
ALTER TABLE {sc}.specimen ADD specimen_id serial8 NOT NULL;
CREATE INDEX idx_specimen_concept_id ON {sc}.specimen USING btree (specimen_concept_id);
CREATE INDEX idx_specimen_person_id ON {sc}.specimen USING btree (person_id);