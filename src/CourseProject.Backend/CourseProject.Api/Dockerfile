# Use the ASP.NET base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/CourseProject.Backend

# Copy project files
COPY ["CourseProject.Api/CourseProject.Api.csproj", "CourseProject.Api/"]
COPY ["CourseProject.Infrastructure/CourseProject.Infrastructure.csproj", "CourseProject.Infrastructure/"]
COPY ["CourseProject.Application/CourseProject.Application.csproj", "CourseProject.Application/"]
COPY ["CourseProject.Domain/CourseProject.Domain.csproj", "CourseProject.Domain/"]
COPY ["CourseProject.Persistence/CourseProject.Persistence.csproj", "CourseProject.Persistence/"]

# Restore the dependencies
RUN dotnet restore "CourseProject.Api/CourseProject.Api.csproj"

# Copy the rest of the application files
COPY . .

# Build the application
# Stay in the Backend directory
RUN dotnet build "CourseProject.Api/CourseProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CourseProject.Api/CourseProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage for runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseProject.Api.dll"]
