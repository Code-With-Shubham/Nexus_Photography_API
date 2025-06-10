# Use the .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project and publish
COPY . ./
RUN dotnet publish -c Release -o out

# Use the ASP.NET runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expose port 80
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "Nexus_Photography_API.dll"]
