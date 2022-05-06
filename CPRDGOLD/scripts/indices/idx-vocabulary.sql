CREATE UNIQUE INDEX idx_vocabulary_vocabulary_id ON {vs}.vocabulary USING btree (vocabulary_id);
CREATE UNIQUE INDEX xpk_vocabulary ON {vs}.vocabulary USING btree (vocabulary_id);