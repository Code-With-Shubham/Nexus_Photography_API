# Use SDK image to build app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY Nexus_Photography_API/*.csproj ./Nexus_Photography_API/
WORKDIR /app/Nexus_Photography_API
RUN dotnet restore

# Copy the rest of the files and build
COPY Nexus_Photography_API/. ./ 
RUN dotnet publish -c Release -o out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/Nexus_Photography_API/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Nexus_Photography_API.dll"]
