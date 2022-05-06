CREATE INDEX idx_note_concept_id ON {sc}.note USING btree (note_type_concept_id);
CREATE INDEX idx_note_person_id ON {sc}.note USING btree (person_id);
CREATE INDEX idx_note_visit_id ON {sc}.note USING btree (visit_occurrence_id);
CREATE UNIQUE INDEX xpk_note ON {sc}.note USING btree (note_id);