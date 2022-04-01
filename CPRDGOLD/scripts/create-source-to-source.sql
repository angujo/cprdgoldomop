DROP TABLE IF EXISTS {ss}.source_to_source;

CREATE TABLE {ss}.source_to_source (
	source_code varchar NULL,
	source_concept_id int4 NULL,
	source_code_description varchar(255) NULL,
	source_vocabulary_id varchar(20) NULL,
	source_domain_id varchar(20) NULL,
	source_concept_class_id varchar(20) NULL,
	source_valid_start_date date NULL,
	source_valid_end_date date NULL,
	source_invalid_reason varchar(1) NULL,
	target_concept_id int4 NULL,
	target_concept_name varchar(255) NULL,
	target_vocabulary_id varchar(20) NULL,
	target_domain_id varchar(20) NULL,
	target_concept_class_id varchar(20) NULL,
	target_invalid_reason varchar(1) NULL,
	target_standard_concept varchar(1) NULL
);