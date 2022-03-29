DROP TABLE IF EXISTS {ss}.daysupply_modes;

CREATE TABLE {ss}.daysupply_modes (
	id bigserial NOT NULL,
	prodcode int4 NOT NULL,
	numdays int2 NULL,
	CONSTRAINT daysupply_modes_pkey PRIMARY KEY (id)
);