# HappyPlanter-api

HappyPlanter is a system that helps plant parents keep track of their plant babies. This is the repo for the api!

**To run the project via docker:**
_(Prerequisite is to have docker installed on your computer. Follow dockers own tutorial)_

1. Step into the folder `/HappyPlanter`
1. Build the docker image and tag it with the command `docker build -t happyplanter .`
1. Run the docker container and expose it to port `:8000` on localhost with the command `docker run -p 8000:80 happyplanter`
1. Now you should be able to reach the api data via `localhost:8000/weatherforecast`
1. Currently there is only scaffolded code, so you will get back some weather forecasts! Hooray!
