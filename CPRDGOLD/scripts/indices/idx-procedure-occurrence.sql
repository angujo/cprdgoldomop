ALTER TABLE {sc}.procedure_occurrence DROP COLUMN IF EXISTS procedure_occurrence_id;
ALTER TABLE {sc}.procedure_occurrence ADD procedure_occurrence_id serial8 NOT NULL;
CREATE INDEX idx_procedure_concept_id ON {sc}.procedure_occurrence USING btree (procedure_concept_id);
CREATE INDEX idx_procedure_person_id ON {sc}.procedure_occurrence USING btree (person_id);
CREATE INDEX idx_procedure_visit_id ON {sc}.procedure_occurrence USING btree (visit_occurrence_id);