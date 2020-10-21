#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Api.Core/Api.Core.csproj", "Api.Core/"]
COPY ["Api.Models/Api.Models.csproj", "Api.Models/"]
COPY ["Api.Repositories/Api.Repositories.csproj", "Api.Repositories/"]
COPY ["Api.Data/Api.Data.csproj", "Api.Data/"]
COPY ["Api.Services/Api.Services.csproj", "Api.Services/"]
RUN dotnet restore "Api.Core/Api.Core.csproj"
COPY . .
WORKDIR "/src/Api.Core"
RUN dotnet build "Api.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.Core.dll"]