ALTER TABLE {sc}.observation_period ADD observation_period_id serial8 NOT NULL;
CREATE INDEX idx_observation_period_id ON {sc}.observation_period USING btree (person_id);