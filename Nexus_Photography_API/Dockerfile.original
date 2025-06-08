# Use base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Nexus_Photography_API/Nexus_Photography_API.csproj", "Nexus_Photography_API/"]
RUN dotnet restore "Nexus_Photography_API/Nexus_Photography_API.csproj"
COPY . .
WORKDIR "/src/Nexus_Photography_API"
RUN dotnet build "Nexus_Photography_API.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "Nexus_Photography_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nexus_Photography_API.dll"]
