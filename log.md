### Log for creation of view

_2020-05-11_
I managed to create a view with the query created with Antons help!

```sql
CREATE VIEW intervals AS

WITH plant_ids AS (SELECT DISTINCT plant_id FROM event),
dates AS (SELECT
	PI.plant_id,
    (SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1) AS latest_time,
    (SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1 OFFSET 4) AS fifth_time
FROM plant_ids PI)


SELECT
    dates.plant_id,
    age(dates.latest_time, dates.fifth_time) / 5 AS interval_time,
    dates.latest_time
FROM dates
```

_2020-05-06_
I got some help from Anton and he wrote me this query

```sql
WITH plant_ids AS SELECT DISTINCT plant_id FROM event

CREATE OR REPLACE VIEW plant_view AS
SELECT
	PI.plant_id,
	max(SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1) AS latest_time,
	max(SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1 OFFSET 4) AS fifth_time,
	age(latest_time, fifth_time) AS interval_int
FROM plant_ids PI
```

I have since refined it to run!
It now looks like this:

```sql
WITH plant_ids AS (SELECT DISTINCT plant_id FROM event),
dates AS (SELECT
	PI.plant_id,
    (SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1) AS latest_time,
    (SELECT time_stamp FROM event WHERE plant_id = PI.plant_id ORDER BY time_stamp DESC LIMIT 1 OFFSET 4) AS fifth_time
FROM plant_ids PI)

SELECT age(dates.latest_time, dates.fifth_time) / 5 AS test FROM dates
```

_2020-05-04_
Today I managed to get call `age` with values from the database!

```sql
WITH last5 AS
(SELECT * FROM event
    WHERE plant_id=3
    ORDER BY time_stamp DESC
    LIMIT 5),
latest AS
    (SELECT time_stamp, plant_id FROM last5 LIMIT 1),
fifth AS
    (SELECT time_stamp, plant_id FROM last5 LIMIT 1 OFFSET 4)

SELECT latest.plant_id, latest.time_stamp AS latest_time, fifth.time_stamp AS fifth_time, age(latest.time_stamp, fifth.time_stamp) AS interval_int
FROM latest
INNER JOIN fifth ON fifth.plant_id=latest.plant_id;
```

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
