# get base image (full .net core sdk)
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# copy csporj and restore
COPY . ./
RUN dotnet publish -c Release -o out

# generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Music.dll" ]