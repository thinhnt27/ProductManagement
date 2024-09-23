#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SWP.ProductManagement.API/SWP.ProductManagement.API.csproj", "SWP.ProductManagement.API/"]
COPY ["SWP.ProductManagement.Service/SWP.ProductManagement.Service.csproj", "SWP.ProductManagement.Service/"]
COPY ["SWP.ProductManagement.Repository/SWP.ProductManagement.Repository.csproj", "SWP.ProductManagement.Repository/"]
RUN dotnet restore "./SWP.ProductManagement.API/SWP.ProductManagement.API.csproj"
COPY . .
WORKDIR "/src/SWP.ProductManagement.API"
RUN dotnet build "./SWP.ProductManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SWP.ProductManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SWP.ProductManagement.API.dll"]