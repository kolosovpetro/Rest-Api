#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SQLServerRestApi/SQLServerRestApi.csproj", "SQLServerRestApi/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["Data/Data.csproj", "Data/"]
RUN dotnet restore "SQLServerRestApi/SQLServerRestApi.csproj"
COPY . .
WORKDIR "/src/SQLServerRestApi"
RUN dotnet build "SQLServerRestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SQLServerRestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SQLServerRestApi.dll"]