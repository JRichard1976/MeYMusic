FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ./MeYMusic ./MeYMusic/
COPY ./MeMyMusicData ./MeMyMusicData/
WORKDIR /app/MeYMusic/
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/published-app /app
COPY ./MeYMusic/MeYMusicDb.db /app/MeYMusicDb.db
COPY ./MeYMusic/MeYMusicDb.db-shm /app/MeYMusicDb.db-shm
COPY ./MeYMusic/MeYMusicDb.db-wal /app/MeYMusicDb.db-wal
ENTRYPOINT ["dotnet", "MeYMusic.dll"]