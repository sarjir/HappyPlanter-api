# HappyPlanter-api

HappyPlanter is a system that helps plant parents keep track of their plant babies. This is the repo for the api!

**To run the project via docker:**
_(Prerequisite is to have docker and docker-compose installed on your computer. Follow dockers own tutorial)_

1. Step into the directory `/HappyPlanter`
1. Build the docker images by running `docker-compose build`.
1. Run the project by running `docker-compose up`
1. Now you should be able to reach the api data via `localhost:8000/weatherforecast`
1. You also get an instance of the Postgres database that is exposed on port `:5432`
1. Currently there is only scaffolded code, so you will get back some weather forecasts! Hooray!
