CREATE UNIQUE INDEX idx_relationship_rel_id ON {vs}.relationship USING btree (relationship_id);
CREATE UNIQUE INDEX xpk_relationship ON {vs}.relationship USING btree (relationship_id);