ALTER TABLE {sc}.death ADD CONSTRAINT death_pk PRIMARY KEY (person_id);
CREATE INDEX idx_death_person_id ON {sc}.death USING btree (person_id);
CREATE UNIQUE INDEX xpk_death ON {sc}.death USING btree (person_id);