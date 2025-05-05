# Base image with ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files
COPY . .

# Restore, build, and publish the app
RUN dotnet restore "Website.csproj"
RUN dotnet publish "Website.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "Website.dll"]
