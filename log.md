### Log for creation of view

_2020-05-03_
Today I have begun creating the database view where I will store the interval for the plants.
This is how far I've got. In the snippet below I store "variables" for the latest 5 plants, and find the first and the last of those five. These will in turn be used to calculate the interval.

I need to figure out how I can do this for each plant, not just for `plant_id=3`.

```sql
WITH last5 AS
(SELECT * FROM event
WHERE plant_id=3
ORDER BY time_stamp DESC
LIMIT 5),
latest AS
(SELECT * FROM last5 LIMIT 1),
fifth AS
(SELECT * FROM last5 LIMIT 1 OFFSET 4)

CREATE VIEW view_name AS
SELECT * FROM fifth
```
