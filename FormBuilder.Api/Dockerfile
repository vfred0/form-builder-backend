FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FormBuilder.Api/FormBuilder.Api.csproj", "FormBuilder.Api/"]
RUN dotnet restore "FormBuilder.Api/FormBuilder.Api.csproj"
COPY . .
WORKDIR "/src/FormBuilder.Api"
RUN dotnet build "FormBuilder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FormBuilder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Install EF Core tools
RUN dotnet tool install --global dotnet-ef

# Add EF Core tools to PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy migration files
COPY ["FormBuilder.Api/Migrations", "/app/Migrations"]
COPY ["FormBuilder.Persistence", "/src/FormBuilder.Persistence"]
COPY ["FormBuilder.Entities", "/src/FormBuilder.Entities"]

# Run migrations
RUN dotnet ef database update

# Seed data
COPY ["FormBuilder.Api/Migrations.cs", "/app/"]
RUN dotnet run --project FormBuilder.Api.csproj -- seed-data


ENTRYPOINT ["dotnet", "FormBuilder.Api.dll"]
