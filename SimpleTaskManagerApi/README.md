# Install Entity Framework Core .NET 8 version

```
dotnet add package Npgsql --version 8.*
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.*
dotnet add package Microsoft.EntityFrameworkCore --version 8.*
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.*
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.*
```

# Migrations

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
