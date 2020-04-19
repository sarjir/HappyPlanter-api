FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore HappyPlanter.csproj
COPY . ./
RUN dotnet publish HappyPlanter.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "HappyPlanter.dll"]