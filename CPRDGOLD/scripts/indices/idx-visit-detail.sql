CREATE INDEX idx_visit_detail_concept_id ON {sc}.visit_detail USING btree (visit_detail_concept_id);
CREATE INDEX idx_visit_detail_person_id ON {sc}.visit_detail USING btree (person_id);
CREATE UNIQUE INDEX xpk_visit_detail ON {sc}.visit_detail USING btree (visit_detail_id);
CREATE INDEX idx_visit_detail_occurrence_id ON {sc}.visit_detail USING btree (visit_occurrence_id);