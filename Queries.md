### Happy Planter Database

This project is using a postgres database. It revolves around events of plants, and it looks like this:
![HappyPlanter (3)](</assets/HappyPlanter%20(3).png>)

The word `user`is a keyword in SQL though, and the word `planter` has been used instead to represent users of HappyPlanter.

### Create tables

A description of how to add tables to the database until there is a script doing this. The queries are in in dependency order.

```sql
CREATE TABLE area (
  id SERIAL PRIMARY KEY,
  name VARCHAR NOT NULL,
)
```

```sql
CREATE TABLE location (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL,
    area_id SERIAL,
    FOREIGN KEY (area_id) REFERENCES area(id)
)
```

```sql
CREATE TABLE species (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL
)
```

```sql
CREATE TABLE planter (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR NOT NULL,
    user_name VARCHAR NOT NULL,
    last_name VARCHAR,
    email VARCHAR(320) NOT NULL
)
```

```sql
CREATE TABLE plant (
    id SERIAL PRIMARY KEY,
    name VARCHAR NOT NULL,
    species_id SERIAL,
    location_id SERIAL,
    planter_id SERIAL,
    FOREIGN KEY (species_id) REFERENCES species(id),
    FOREIGN KEY (location_id) REFERENCES location(id),
    FOREIGN KEY (planter_id) REFERENCES planter(id)
)
```

```sql
CREATE TYPE event_type AS enum('water', 'repot', 'give nutrients')
```

```sql
CREATE TABLE event (
    id SERIAL PRIMARY KEY,
    time_stamp DATE,
    event_type event_type,
    plant_id SERIAL,
    FOREIGN KEY (plant_id) REFERENCES plant(id)
)
```
