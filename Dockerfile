# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY Wallet.sln ./
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY WebApi/*.csproj ./WebApi/
# Restore
RUN dotnet restore

COPY . .

WORKDIR /src/Application
RUN dotnet build -c Release -o /app

WORKDIR /src/Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /src/WebApi
RUN dotnet build -c Release -o /app

# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=publish /app .

EXPOSE 8080

ENTRYPOINT ["dotnet", "WebApi.dll"]