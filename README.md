# UrlShortner API
A simple way to get your URL shorten.

---
# Tech stack
- C# v10
- .NET Core (v6)
- Entity Framework Core
- Fast Endpoints => [link here](https://www.nuget.org/packages/FastEndpoints)
- Fluent Validation => [link here](https://docs.fluentvalidation.net/en/latest/)
- NanoId => [link here](https://www.nuget.org/packages/Nanoid/)
---
# Patters
- Domain Driven Design
- Dependency Injection
- SOLID (I tried 😂😂)
- Repository pattern
---
# Install instructions
> **Requirements**
> > 1. .NET Entity Framework Core CLI installed
> > ```bash
> > dotnet tool install --global dotnet-ef
> > ```
> > 2. SQL Server Installed
> > * Check appsettings.json/ appsettins.Development.json in order to know/ change the DB connection
---
1. Clone the repository
```bash
git clone https://github.com/GlennMateus/UrlShortner.git
```

2.  Execute migrations:
```bash
dotnet ef database update 
```
---
# TODO
[ ] Implement unit tests
[ ] Implement integration tests
[ ] Implement deployment pipelines
[ ] Upload to a cloud server (AWS/ Azure)
