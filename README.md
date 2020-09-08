# Rest API Docker Demo

## Description

Moving forward from recent project [Complete Code First Approach](https://github.com/kolosovpetro/Complete-CodeFirst-Approach), we create a `REST API` for movie/actors data with `CRUD` options. Includes `Docker` support for `PostgreSQL` and `MS SQL Server`. Implemented according to scheme below

![DbSchema](/Api.Schema/api_schema.jpg)

## Endpoints

- Movies
  - `GET`
    - api/movies
	- api/movies/{id}
  - `POST`
    - api/movies
  - `PUT`
    - api/movies/{id}
  - `PATCH`
    - api/movies/{id}
  - `DELETE`
    - api/movies/{id}

## Run Docker Container

- MS SQL Server
  - Copy files `DockerFile`, `docker-compose.yml` from `DockerCofigs/SqlServerDockerConfig` folder to root folder
  - In `Startup.cs` switch dependency injection of `DbContext` to `RentalContextSqlServer`
  - `docker-compose build`
  - `docker-compose up`
  - Navigate to http://localhost:8000/swagger

- PostgreSQL
  - Copy files `DockerFile`, `docker-compose.yml` from `DockerCofigs/PostgresDockerConfig` folder to root folder
  - In `Startup.cs` switch dependency injection of `DbContext` to `RentalContext`
  - `docker-compose build`
  - `docker-compose up`
  - Navigate to http://localhost:8000/swagger
  
- MS SQL Server in separated containers
  - Copy `Dockerfile` from folder `DockerCofigs/DockerSqlServerSeparateContainers` to the root folder
  - `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yrnn9&kDt-' -p 5000:1433 --name sqlserverimage -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu`
  - Get your inner ip from `ipconfig`
  - `docker build -t movies --build-arg CONN_STR="Server=<inner_ip>,5000;Database=RentalCodeFirst;User Id=sa;Password=yrnn9&kDt-;" .`
  - `docker run -d -p 9000:80 --name sqlserverdockerapi -e ConnectionStrings__DB_CONNECTION_STRING="Server=<inner_ip>,5000;Database=RentalCodeFirst;User Id=sa;Password=yrnn9&kDt-;" movies`
  - Navigate to http://localhost:9000/swagger
  
## To improve
   - ~~Move logics from controller to services~~
   - Add authentification
   - Improve documentation
   - ~~Make API methods to be async~~
   - ~~Configure swagger~~
  
## Notes

- To validate `PATCH` endpoint use JSON structure

```
[
    {
        "op":  "replace",
        "path": "/title",
        "value": "Lord of the rings: Two towers full updated 2"
    }
]
```

- To validate `POST` endpoint

```
{
    "title": "Lord of the rings",
    "year": 2003,
    "ageRestriction": 12,
    "price": 11
}
```

- Related info https://youtu.be/fmvcAzHpsk8
- To config swagger https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle
- Docker image: https://hub.docker.com/repository/docker/1337322420/rest-api-docker-demo
- In order to have 'HasName' fluent api properties it should be installed: Microsoft.EntityFrameworkCore.Relational
- Migrations command: dotnet ef migrations add InitialMigration --project Api.Data --context RentalContextSqlServer
- Database update: 