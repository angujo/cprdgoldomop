CREATE INDEX idx_drug_strength_id_1 ON {sc}.drug_strength USING btree (drug_concept_id);
CREATE INDEX idx_drug_strength_id_2 ON {sc}.drug_strength USING btree (ingredient_concept_id);
CREATE UNIQUE INDEX xpk_drug_strength ON {sc}.drug_strength USING btree (drug_concept_id, ingredient_concept_id);