CREATE INDEX idx_period_person_id ON {sc}.payer_plan_period USING btree (person_id);
CREATE UNIQUE INDEX xpk_payer_plan_period ON {sc}.payer_plan_period USING btree (payer_plan_period_id);