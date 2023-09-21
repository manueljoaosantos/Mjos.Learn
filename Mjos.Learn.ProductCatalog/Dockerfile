#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mjos.Learn.ProductCatalog/Mjos.Learn.ProductCatalog.csproj", "Mjos.Learn.ProductCatalog/"]
COPY ["shared/Mjos.Learn.Core/Mjos.Learn.Core.csproj", "shared/Mjos.Learn.Core/"]
COPY ["shared/Mjos.Learn.Infrastructure.EfCore/Mjos.Learn.Infrastructure.EfCore.csproj", "shared/Mjos.Learn.Infrastructure.EfCore/"]
COPY ["shared/Mjos.Learn.Infrastructure/Mjos.Learn.Infrastructure.csproj", "shared/Mjos.Learn.Infrastructure/"]
COPY ["shared/Mjos.Learn.Northwind.IntegrationEvents/Mjos.Learn.Northwind.IntegrationEvents.csproj", "shared/Mjos.Learn.Northwind.IntegrationEvents/"]
RUN dotnet restore "Mjos.Learn.ProductCatalog/Mjos.Learn.ProductCatalog.csproj"
COPY . .
WORKDIR "/src/Mjos.Learn.ProductCatalog"
RUN dotnet build "Mjos.Learn.ProductCatalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mjos.Learn.ProductCatalog.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mjos.Learn.ProductCatalog.dll"]