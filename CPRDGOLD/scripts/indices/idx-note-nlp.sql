CREATE INDEX idx_note_nlp_concept_id ON {sc}.note_nlp USING btree (note_nlp_concept_id);
CREATE INDEX idx_note_nlp_note_id ON {sc}.note_nlp USING btree (note_id);
CREATE UNIQUE INDEX xpk_note_nlp ON {sc}.note_nlp USING btree (note_nlp_id);