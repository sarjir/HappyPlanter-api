# HappyPlanter-api

HappyPlanter is a system that helps plant parents keep track of their plant babies. This is the repo for the api!

To run the project:

1. Download the .NET core sdk to get the dotnet cli and runtime
1. If it's your first time running the project, create a https dev-cert and trust it by running these commands inside the HappyPlanter folder:
    1. `dotnet dev-certs https`
    1. `dotnet dev-certs https --trust`
   (_this process might be cumbersome on a later versions of macOS. If you're having troubles with the certificates, look at this article: [Troubleshooting .NET Core Dev Certs on MacOS](https://dev.to/cesarcodes/troubleshooting-net-core-dev-certs-on-macos-179d)_)
1. Open up the folder `HappyPlanter` in VScode
1. Start debugging by clicking `Run > Start debugging` or pressing `F5`
1. Go to `localhost:5001/weatherforecast`
1. Currently there is only scaffolded code, so you will get back some weather forecasts! Hooray!
