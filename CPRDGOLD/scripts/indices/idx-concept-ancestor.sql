CREATE INDEX idx_concept_ancestor_id_1 ON {vs}.concept_ancestor USING btree (ancestor_concept_id);
CREATE INDEX idx_concept_ancestor_id_2 ON {vs}.concept_ancestor USING btree (descendant_concept_id);
CREATE UNIQUE INDEX xpk_concept_ancestor ON {vs}.concept_ancestor USING btree (ancestor_concept_id, descendant_concept_id);