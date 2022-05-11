# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0.300-alpine3.15 as build
WORKDIR /source
COPY . .
RUN dotnet restore "./UrlShortening.Domain/UrlShortening.Domain.csproj" --disable-parallel
RUN dotnet restore "./UrlShortening.Repository/UrlShortening.Repository.csproj" --disable-parallel
RUN dotnet restore "./UrlShortening.API/UrlShortening.API.csproj" --disable-parallel
RUN dotnet publish "./UrlShortening.API/UrlShortening.API.csproj" -c release -o /app --no-restore
RUN dotnet dev-certs https --trust

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0.300-alpine3.15
WORKDIR /app
COPY --from=build /app ./
EXPOSE 5000

ENTRYPOINT ["dotnet", "UrlShortening.API.dll"]