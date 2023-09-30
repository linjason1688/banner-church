# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy everything else and build app
COPY ./ ./
RUN dotnet restore
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN apt update && apt-get install --assume-yes libgdiplus && ln -s /usr/lib/libgdiplus.so gdiplus.dll
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "App.Api.dll", "--environment=TK"]
