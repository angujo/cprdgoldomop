ALTER TABLE {sc}.cost DROP COLUMN IF EXISTS cost_id;
ALTER TABLE {sc}.cost ADD cost_id serial8 NOT NULL;