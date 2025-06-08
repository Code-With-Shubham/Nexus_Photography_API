# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

# Use the official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Nexus_Photography_API/Nexus_Photography_API.csproj", "Nexus_Photography_API/"]
RUN dotnet restore "Nexus_Photography_API/Nexus_Photography_API.csproj"

# Copy the rest of the source code
COPY . .

WORKDIR "/src/Nexus_Photography_API"
RUN dotnet publish "Nexus_Photography_API.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80 (default for ASP.NET Core)
EXPOSE 80

# Set the entrypoint
ENTRYPOINT ["dotnet", "Nexus_Photography_API.dll"]

# Build the Docker image
# docker build -t nexus-photography-api .

# Run the Docker container
# docker run -d -p 8080:80 --name nexus-photography-api nexus-photography-api

docker build -f Nexus_Photography_API/Dockerfile -t nexus-photography-api .