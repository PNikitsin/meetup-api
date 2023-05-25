## Meetup API

* ASP.NET Core
* EntityFrameworkCore
* Microsoft SQL Server
* AutoMapper
* Serilog
* Swagger UI

## Short description

The application is an API that performs CRUD (Create, Read, Modify, and Delete) operations. Only authorized users have access to operations. The application is developed in accordance with the modern Domain-Driven Design approach. Data access is implemented using the Repository and unit of work pattern.

## Project start instructions

All application settings are in the appsettings.json file.

```
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=meetupsdb;Trusted_Connection=True;"
  },
  "Token": {
    "Key": "C1CF4B7DC4C4175B6618DE4F55CA4",
    "DurationInMinutes": 480
  },
```
If necessary, you can specify your database connection string or token key. The database is created automatically when the application starts using migration.
