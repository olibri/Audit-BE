#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Audit/Audit.csproj", "Audit/"]
COPY ["AuditApplication/AuditApplication.csproj", "AuditApplication/"]
COPY ["AuditDomain/AuditDomain.csproj", "AuditDomain/"]
COPY ["AuditInfrastructure/AuditInfrastructure.csproj", "AuditInfrastructure/"]
RUN dotnet restore "./Audit/./Audit.csproj"
COPY . .
WORKDIR "/src/Audit"
RUN dotnet build "./Audit.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Audit.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Audit.dll"]
#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#COPY ["path/to/your/certificate.crt", "/usr/local/share/ca-certificates/"]
#RUN update-ca-certificates
#