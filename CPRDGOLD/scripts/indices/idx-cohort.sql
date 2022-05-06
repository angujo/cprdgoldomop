CREATE INDEX idx_cohort_c_definition_id ON {sc}.cohort USING btree (cohort_definition_id);
CREATE INDEX idx_cohort_subject_id ON {sc}.cohort USING btree (subject_id);
CREATE UNIQUE INDEX xpk_cohort ON {sc}.cohort USING btree (cohort_definition_id, subject_id, cohort_start_date, cohort_end_date);