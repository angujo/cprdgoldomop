delete
from {sc}.visit_occurrence vo
where vo.ctid in
    (select vo2.ctid from {sc}.visit_occurrence vo2
    join (select ctid vctid
    , visit_occurrence_id
    , row_number() over(partition by visit_occurrence_id
    , visit_start_date) rnum
    from {sc}.visit_occurrence vo) v on v.vctid =vo2.ctid
    where rnum
    > 1);
ALTER TABLE {sc}.visit_occurrence DROP CONSTRAINT IF EXISTS visit_occurrence_pk;
ALTER TABLE {sc}.visit_occurrence ADD CONSTRAINT visit_occurrence_pk PRIMARY KEY (visit_occurrence_id);
CREATE INDEX idx_visit_concept_id ON {sc}.visit_occurrence USING btree (visit_concept_id);
CREATE INDEX idx_visit_person_id ON {sc}.visit_occurrence USING btree (person_id);
CREATE UNIQUE INDEX xpk_visit_occurrence ON {sc}.visit_occurrence USING btree (visit_occurrence_id);