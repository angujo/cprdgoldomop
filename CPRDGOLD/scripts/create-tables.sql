-- {sc}."_chunk" definition



-- {sc}.attribute_definition definition

-- Drop

--DROP TABLE IF EXISTS {sc}.attribute_definition;

--CREATE TABLE {sc}.attribute_definition (
--	attribute_definition_id int8 NULL,
--	attribute_name varchar(255) NULL,
--	attribute_description text NULL,
--	attribute_type_concept_id int4 NULL,
--	attribute_syntax text NULL
--);


-- {sc}.care_site definition

-- Drop

DROP TABLE IF EXISTS {sc}.care_site;

CREATE TABLE {sc}.care_site (
	care_site_id int8 NULL,
	care_site_name varchar(255) NULL,
	place_of_service_concept_id int8 NULL,
	location_id int8 NULL,
	care_site_source_value varchar(50) NULL,
	place_of_service_source_value varchar(50) NULL
);


-- {sc}.cdm_domain_meta definition

-- Drop

--DROP TABLE IF EXISTS {sc}.cdm_domain_meta;

--CREATE TABLE {sc}.cdm_domain_meta (
--	domain_id varchar(20) NULL,
--	description varchar(4000) NULL
--);


-- {sc}.cdm_source definition

-- Drop

DROP TABLE IF EXISTS {sc}.cdm_source;

CREATE TABLE {sc}.cdm_source (
	cdm_source_name varchar(255) NULL,
	cdm_source_abbreviation varchar(25) NULL,
	cdm_holder varchar(255) NULL,
	source_description text NULL,
	source_documentation_reference varchar(255) NULL,
	cdm_etl_reference varchar(255) NULL,
	source_release_date timestamp NULL,
	cdm_release_date timestamp NULL,
	cdm_version varchar(10) NULL,
	vocabulary_version varchar(20) NULL
);


-- {sc}.cohort definition

-- Drop

DROP TABLE IF EXISTS {sc}.cohort;

CREATE TABLE {sc}.cohort (
	cohort_definition_id int4 NULL,
	subject_id int4 NULL,
	cohort_start_date timestamp NULL,
	cohort_end_date timestamp NULL
);


-- {sc}.cohort_attribute definition

-- Drop

DROP TABLE IF EXISTS {sc}.cohort_attribute;

CREATE TABLE {sc}.cohort_attribute (
	cohort_definition_id int4 NULL,
	subject_id int4 NULL,
	cohort_start_date timestamp NULL,
	cohort_end_date timestamp NULL,
	attribute_definition_id int4 NULL,
	value_as_number numeric NULL,
	value_as_concept_id int4 NULL
);


-- {sc}.cohort_definition definition

-- Drop

DROP TABLE IF EXISTS {sc}.cohort_definition;

CREATE TABLE {sc}.cohort_definition (
	cohort_definition_id int4 NULL,
	cohort_definition_name varchar(255) NULL,
	cohort_definition_description text NULL,
	definition_type_concept_id int4 NULL,
	cohort_definition_syntax text NULL,
	subject_concept_id int4 NULL,
	cohort_initiation_date timestamp NULL
);


-- {sc}.condition_era definition

-- Drop

DROP TABLE IF EXISTS {sc}.condition_era;

CREATE TABLE {sc}.condition_era (
	person_id int8 NULL,
	condition_concept_id int4 NULL,
	condition_era_start_date timestamp NULL,
	condition_era_end_date timestamp NULL,
	condition_occurrence_count int4 NULL
);


-- {sc}.condition_occurrence definition

-- Drop

DROP TABLE IF EXISTS {sc}.condition_occurrence;

CREATE TABLE {sc}.condition_occurrence (
	condition_occurrence_id int8 NULL,
	person_id int8 NULL,
	condition_concept_id int4 NULL,
	condition_start_date timestamp NULL,
	condition_start_datetime timestamp NULL,
	condition_end_date timestamp NULL,
	condition_end_datetime timestamp NULL,
	condition_type_concept_id int4 NULL,
	stop_reason varchar(20) NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	condition_status_concept_id int4 NULL,
	condition_source_value varchar(450) NULL,
	condition_source_concept_id int4 NULL,
	condition_status_source_value varchar(50) NULL
);


-- {sc}."cost" definition

-- Drop

DROP TABLE IF EXISTS {SC}."cost";

CREATE TABLE {SC}."cost" (
	COST_ID INT8 NULL,
	COST_EVENT_ID INT8 NULL,
	COST_DOMAIN_ID VARCHAR(20) NULL,
	COST_TYPE_CONCEPT_ID INT4 NULL,
	CURRENCY_CONCEPT_ID INT4 NULL,
	TOTAL_CHARGE NUMERIC NULL,
	TOTAL_COST NUMERIC NULL,
	TOTAL_PAID NUMERIC NULL,
	PAID_BY_PAYER NUMERIC NULL,
	PAID_BY_PATIENT NUMERIC NULL,
	PAID_PATIENT_COPAY NUMERIC NULL,
	PAID_PATIENT_COINSURANCE NUMERIC NULL,
	PAID_PATIENT_DEDUCTIBLE NUMERIC NULL,
	PAID_BY_PRIMARY NUMERIC NULL,
	PAID_INGREDIENT_COST NUMERIC NULL,
	PAID_DISPENSING_FEE NUMERIC NULL,
	PAYER_PLAN_PERIOD_ID INT8 NULL,
	AMOUNT_ALLOWED NUMERIC NULL,
	REVENUE_CODE_CONCEPT_ID INT4 NULL,
	REVENUE_CODE_SOURCE_VALUE VARCHAR(50) NULL,
	DRG_CONCEPT_ID INT4 NULL,
	DRG_SOURCE_VALUE VARCHAR(3) NULL
);


-- {sc}.death definition

-- Drop

DROP TABLE IF EXISTS {sc}.death;

CREATE TABLE {sc}.death (
	person_id int8  NULL,
	death_date timestamp  NULL,
	death_datetime timestamp NULL,
	death_type_concept_id int4 NULL,
	cause_concept_id int4 NULL,
	cause_source_value varchar(50) NULL,
	cause_source_concept_id int4 NULL
);


-- {sc}.device_exposure definition

-- Drop

DROP TABLE IF EXISTS {sc}.device_exposure;

CREATE TABLE {sc}.device_exposure (
	device_exposure_id int8 NULL,
	person_id int8 NULL,
	device_concept_id int4 NULL,
	device_exposure_start_date timestamp NULL,
	device_exposure_start_datetime timestamp NULL,
	device_exposure_end_date timestamp NULL,
	device_exposure_end_datetime timestamp NULL,
	device_type_concept_id int4 NULL,
	unique_device_id varchar(50) NULL,
	quantity int4 NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	device_source_value varchar(100) NULL,
	device_source_concept_id int4 NULL
);


-- {sc}.dose_era definition

-- Drop

DROP TABLE IF EXISTS {sc}.dose_era;

CREATE TABLE {sc}.dose_era (
	dose_era_id int8 NULL,
	person_id int4 NULL,
	drug_concept_id int4 NULL,
	unit_concept_id int4 NULL,
	dose_value numeric NULL,
	dose_era_start_date timestamp NULL,
	dose_era_end_date timestamp NULL
);


-- {sc}.drug_era definition

-- Drop

DROP TABLE IF EXISTS {sc}.drug_era;

CREATE TABLE {sc}.drug_era (
	drug_era_id int8 NULL,
	person_id int8 NULL,
	drug_concept_id int4 NULL,
	drug_era_start_date timestamp NULL,
	drug_era_end_date timestamp NULL,
	drug_exposure_count int4 NULL,
	gap_days int4 NULL
);


-- {sc}.drug_exposure definition

-- Drop

DROP TABLE IF EXISTS {sc}.drug_exposure;

CREATE TABLE {sc}.drug_exposure (
	drug_exposure_id int8 NULL,
	person_id int8 NULL,
	drug_concept_id int4 NULL,
	drug_exposure_start_date timestamp NULL,
	drug_exposure_start_datetime timestamp NULL,
	drug_exposure_end_date timestamp NULL,
	drug_exposure_end_datetime timestamp NULL,
	verbatim_end_date timestamp NULL,
	drug_type_concept_id int4 NULL,
	stop_reason varchar(20) NULL,
	refills int4 NULL,
	quantity numeric NULL,
	days_supply int4 NULL,
	sig text NULL,
	route_concept_id int4 NULL,
	lot_number varchar(50) NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	drug_source_value varchar(50) NULL,
	drug_source_concept_id int4 NULL,
	route_source_value varchar(50) NULL,
	dose_unit_source_value varchar(50) NULL
);


-- {sc}.fact_relationship definition

-- Drop

--DROP TABLE IF EXISTS {sc}.fact_relationship;

--CREATE TABLE {sc}.fact_relationship (
--	domain_concept_id_1 int4 NULL,
--	fact_id_1 int4 NULL,
--	domain_concept_id_2 int4 NULL,
--	fact_id_2 int4 NULL,
--	relationship_concept_id int4 NULL
--);


-- {sc}."location" definition

-- Drop

DROP TABLE IF EXISTS {sc}."location";

CREATE TABLE {sc}."location" (
	location_id int8 NULL,
	address_1 varchar(50) NULL,
	address_2 varchar(50) NULL,
	city varchar(50) NULL,
	state varchar(2) NULL,
	zip varchar(9) NULL,
	county varchar(20) NULL,
	location_source_value varchar(50) NULL
);


-- {sc}.measurement definition

-- Drop

DROP TABLE IF EXISTS {sc}.measurement;

CREATE TABLE {sc}.measurement (
	measurement_id int8 NULL,
	person_id int8 NULL,
	measurement_concept_id int4 NULL,
	measurement_date timestamp NULL,
	measurement_datetime timestamp NULL,
	measurement_time varchar(10) NULL,
	measurement_type_concept_id int4 NULL,
	operator_concept_id int4 NULL,
	value_as_number numeric NULL,
	value_as_concept_id int4 NULL,
	unit_concept_id int4 NULL,
	range_low numeric NULL,
	range_high numeric NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	measurement_source_value varchar(100) NULL,
	measurement_source_concept_id int4 NULL,
	unit_source_value varchar(50) NULL,
	value_source_value varchar(2500) NULL
);


-- {sc}.metadata definition

-- Drop

--DROP TABLE IF EXISTS {sc}.metadata;

--CREATE TABLE {sc}.metadata (
--	metadata_concept_id int4 NULL,
--	metadata_type_concept_id int4 NULL,
--	"name" varchar(250) NULL,
--	value_as_string text NULL,
--	value_as_concept_id int4 NULL,
--	metadata_date timestamp NULL,
--	metadata_datetime timestamp NULL
--);


-- {sc}.metadata_tmp definition

-- Drop

--DROP TABLE IF EXISTS {sc}.metadata_tmp;

--CREATE TABLE {sc}.metadata_tmp (
--	person_id int8 NULL,
--	"name" varchar(250) NULL
--);


-- {sc}.note definition

-- Drop

DROP TABLE IF EXISTS {sc}.note;

CREATE TABLE {sc}.note (
	note_id int8 NULL,
	person_id int4 NULL,
	note_date timestamp NULL,
	note_datetime timestamp NULL,
	note_type_concept_id int4 NULL,
	note_class_concept_id int4 NULL,
	note_title varchar(250) NULL,
	note_text text NULL,
	encoding_concept_id int4 NULL,
	language_concept_id int4 NULL,
	provider_id int4 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int4 NULL,
	note_source_value varchar(50) NULL
);


-- {sc}.note_nlp definition

-- Drop

DROP TABLE IF EXISTS {sc}.note_nlp;

CREATE TABLE {sc}.note_nlp (
	note_nlp_id int8 NULL,
	note_id int4 NULL,
	section_concept_id int4 NULL,
	snippet varchar(250) NULL,
	"offset" varchar(250) NULL,
	lexical_variant varchar(250) NULL,
	note_nlp_concept_id int4 NULL,
	note_nlp_source_concept_id int4 NULL,
	nlp_system varchar(250) NULL,
	nlp_date timestamp NULL,
	nlp_datetime timestamp NULL,
	term_exists varchar(1) NULL,
	term_temporal varchar(50) NULL,
	term_modifiers varchar(2000) NULL
);


-- {sc}.observation definition

-- Drop

DROP TABLE IF EXISTS {sc}.observation;

CREATE TABLE {sc}.observation (
	observation_id int8 NULL,
	person_id int8 NULL,
	observation_concept_id int4 NULL,
	observation_date timestamp NULL,
	observation_datetime timestamp NULL,
	observation_type_concept_id int4 NULL,
	value_as_number numeric NULL,
	value_as_string varchar(2000) NULL,
	value_as_concept_id int4 NULL,
	qualifier_concept_id int4 NULL,
	unit_concept_id int4 NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	observation_source_value varchar(250) NULL,
	observation_source_concept_id int4 NULL,
	unit_source_value varchar(250) NULL,
	qualifier_source_value varchar(250) NULL
);


-- {sc}.observation_period definition

-- Drop

DROP TABLE IF EXISTS {sc}.observation_period;

CREATE TABLE {sc}.observation_period (
	person_id int8 NULL,
	observation_period_start_date timestamp NULL,
	observation_period_end_date timestamp NULL,
	period_type_concept_id int4 NULL
);

-- {sc}.payer_plan_period definition

-- Drop

DROP TABLE IF EXISTS {sc}.payer_plan_period;

CREATE TABLE {sc}.payer_plan_period (
	payer_plan_period_id int8 NULL,
	person_id int8 NULL,
	payer_plan_period_start_date timestamp NULL,
	payer_plan_period_end_date timestamp NULL,
	payer_concept_id int4 NULL,
	payer_source_value varchar(50) NULL,
	payer_source_concept_id int4 NULL,
	plan_concept_id int4 NULL,
	plan_source_value varchar(50) NULL,
	plan_source_concept_id int4 NULL,
	sponsor_concept_id int4 NULL,
	sponsor_source_value varchar(50) NULL,
	sponsor_source_concept_id int4 NULL,
	family_source_value varchar(50) NULL,
	stop_reason_concept_id int4 NULL,
	stop_reason_source_value varchar(50) NULL,
	stop_reason_source_concept_id int4 NULL
);


-- {sc}.person definition

-- Drop

DROP TABLE IF EXISTS {sc}.person;

CREATE TABLE {sc}.person (
	person_id int8 NULL,
	gender_concept_id int4 NULL,
	year_of_birth int4 NULL,
	month_of_birth int4 NULL,
	day_of_birth int4 NULL,
	birth_datetime text NULL,
	race_concept_id int4 NULL,
	ethnicity_concept_id int4 NULL,
	location_id int8 NULL,
	provider_id int8 NULL,
	care_site_id int8 NULL,
	person_source_value varchar(50) NULL,
	gender_source_value varchar(50) NULL,
	gender_source_concept_id int4 NULL,
	race_source_value varchar(50) NULL,
	race_source_concept_id int4 NULL,
	ethnicity_source_value varchar(50) NULL,
	ethnicity_source_concept_id int4 NULL
);


-- {sc}.procedure_occurrence definition

-- Drop

DROP TABLE IF EXISTS {sc}.procedure_occurrence;

CREATE TABLE {sc}.procedure_occurrence (
	procedure_occurrence_id int8 NULL,
	person_id int8 NULL,
	procedure_concept_id int4 NULL,
	procedure_date timestamp NULL,
	procedure_datetime timestamp NULL,
	procedure_type_concept_id int4 NULL,
	modifier_concept_id int4 NULL,
	quantity int4 NULL,
	provider_id int8 NULL,
	visit_occurrence_id int8 NULL,
	visit_detail_id int8 NULL,
	procedure_source_value varchar(50) NULL,
	procedure_source_concept_id int4 NULL,
	modifier_source_value varchar(50) NULL
);


-- {sc}.provider definition

-- Drop

DROP TABLE IF EXISTS {sc}.provider;

CREATE TABLE {sc}.provider (
	provider_id int8 NULL,
	provider_name varchar(255) NULL,
	npi varchar(20) NULL,
	dea varchar(20) NULL,
	specialty_concept_id int4 NULL,
	care_site_id int8 NULL,
	year_of_birth int4 NULL,
	gender_concept_id int4 NULL,
	provider_source_value varchar(50) NULL,
	specialty_source_value varchar(50) NULL,
	specialty_source_concept_id int4 NULL,
	gender_source_value varchar(50) NULL,
	gender_source_concept_id int4 NULL
);




-- {sc}.specimen definition

-- Drop

DROP TABLE IF EXISTS {sc}.specimen;

CREATE TABLE {sc}.specimen (
	specimen_id int8 NULL,
	person_id int8 NULL,
	specimen_concept_id int4 NULL,
	specimen_type_concept_id int4 NULL,
	specimen_date timestamp NULL,
	specimen_datetime timestamp NULL,
	quantity numeric NULL,
	unit_concept_id int4 NULL,
	anatomic_site_concept_id int4 NULL,
	disease_status_concept_id int4 NULL,
	specimen_source_id varchar(50) NULL,
	specimen_source_value varchar(50) NULL,
	unit_source_value varchar(50) NULL,
	anatomic_site_source_value varchar(50) NULL,
	disease_status_source_value varchar(50) NULL
);

-- {sc}.visit_detail definition

-- Drop

DROP TABLE IF EXISTS {sc}.visit_detail;

CREATE TABLE {sc}.visit_detail (
	person_id int8 NULL,
	visit_detail_concept_id int4 NULL,
	visit_detail_start_date timestamp NULL,
	visit_detail_start_datetime timestamp NULL,
	visit_detail_end_date timestamp NULL,
	visit_detail_end_datetime timestamp NULL,
	visit_detail_type_concept_id int4 NULL,
	provider_id int8 NULL,
	care_site_id int8 NULL,
	admitting_source_concept_id int4 NULL,
	discharge_to_concept_id int4 NULL,
	preceding_visit_detail_id int8 NULL,
	visit_detail_source_value varchar(50) NULL,
	visit_detail_source_concept_id int4 NULL,
	admitting_source_value varchar(50) NULL,
	discharge_to_source_value varchar(50) NULL,
	visit_detail_parent_id int8 NULL,
	visit_occurrence_id int8 NULL
);


-- {sc}.visit_occurrence definition

-- Drop

DROP TABLE IF EXISTS {sc}.visit_occurrence;

CREATE TABLE {sc}.visit_occurrence (
	visit_occurrence_id int8 NULL,
	person_id int8 NULL,
	visit_concept_id int4 NULL,
	visit_start_date timestamp NULL,
	visit_start_datetime timestamp NULL,
	visit_end_date timestamp NULL,
	visit_end_datetime timestamp NULL,
	visit_type_concept_id int4 NULL,
	provider_id int8 NULL,
	care_site_id int8 NULL,
	visit_source_value varchar(50) NULL,
	visit_source_concept_id int4 NULL,
	admitting_source_concept_id int4 NULL,
	admitting_source_value varchar(50) NULL,
	discharge_to_concept_id int4 NULL,
	discharge_to_source_value varchar(50) NULL,
	preceding_visit_occurrence_id int8 NULL,
	admitted_from_concept_id int8 NULL,
	admitted_from_source_value varchar NULL,
	discharged_to_concept_id int8 NULL,
	discharged_to_source_value varchar NULL
);