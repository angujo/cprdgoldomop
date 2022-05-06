ALTER TABLE {sc}.visit_detail DROP column if exists visit_detail_id;
ALTER TABLE {sc}.visit_detail ADD visit_detail_id bigserial NOT NULL;
WITH vdetails AS (SELECT visit_detail_id, lag(visit_detail_id, 1) over(partition BY person_id ORDER BY visit_detail_start_date) AS prev_id FROM {sc}.visit_detail)
UPDATE {sc}.visit_detail v SET preceding_visit_detail_id = d.prev_id, visit_detail_parent_id = d.prev_id FROM vdetails d WHERE v.visit_detail_id=d.visit_detail_id;
