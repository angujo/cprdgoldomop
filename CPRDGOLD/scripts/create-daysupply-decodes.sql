DROP TABLE IF EXISTS {ss}.daysupply_decodes;

CREATE TABLE {ss}.daysupply_decodes (
	id bigserial NOT NULL,
	prodcode int4 NOT NULL,
	daily_dose numeric(15, 3) NULL,
	qty numeric(9, 2) NULL,
	numpacks int4 NULL,
	numdays int2 NULL,
	CONSTRAINT daysupply_decodes_pkey PRIMARY KEY (id)
);