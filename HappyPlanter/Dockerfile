FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore HappyPlanter.csproj
COPY . ./
RUN dotnet publish HappyPlanter.csproj -c Release -o out
# ENTRYPOINT ["dotnet", "./out/HappyPlanter.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
# ENTRYPOINT ["dotnet", "run"]

FROM build AS build2
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
COPY --from=runtime /app ./
ENTRYPOINT ["dotnet", "watch", "HappyPlanter.dll"]
# ENTRYPOINT dotnet watch run --no-restore HappyPlanter.dll
