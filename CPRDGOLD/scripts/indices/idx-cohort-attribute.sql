CREATE INDEX idx_ca_definition_id ON {sc}.cohort_attribute USING btree (cohort_definition_id);
CREATE INDEX idx_ca_subject_id ON {sc}.cohort_attribute USING btree (subject_id);
CREATE UNIQUE INDEX xpk_cohort_attribute ON {sc}.cohort_attribute USING btree (cohort_definition_id, subject_id, cohort_start_date, cohort_end_date, attribute_definition_id);