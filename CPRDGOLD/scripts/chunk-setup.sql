/** ChunkSetup */
-- Drop table

DROP INDEX IF EXISTS {ss}.idx_ordinal;
DROP INDEX IF EXISTS {ss}.idx_patient_id;

DROP TABLE IF EXISTS {ss}."_chunk";

CREATE TABLE {ss}."_chunk" (
	id bigserial NOT NULL,
	ordinal int8 NOT NULL,
	patient_id int8 NULL,
	loaded bool NULL DEFAULT false,
	processed bool NULL,
	load_time timestamp NULL,
	end_time timestamp NULL
);
CREATE INDEX idx_ordinal ON {ss}."_chunk" USING btree (ordinal);
CREATE INDEX idx_patient_id ON {ss}."_chunk" USING btree (patient_id);