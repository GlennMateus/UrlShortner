# UrlShortner

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
