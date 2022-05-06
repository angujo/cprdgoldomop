CREATE UNIQUE INDEX idx_domain_domain_id ON {sc}.domain USING btree (domain_id);
CREATE UNIQUE INDEX xpk_domain ON {sc}.domain USING btree (domain_id);