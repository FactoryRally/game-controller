#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Container we use for final publish
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build container
FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

# Copy the code into the container
WORKDIR /src
COPY ["src/Tgm.Roborally.Server/Tgm.Roborally.Server.csproj", "Tgm.Roborally.Server/"]

# NuGet restore
RUN dotnet restore "Tgm.Roborally.Server/Tgm.Roborally.Server.csproj"
COPY ["src/Tgm.Roborally.Server/", "Tgm.Roborally.Server/"]

# Build the API
WORKDIR "Tgm.Roborally.Server"
RUN dotnet build "Tgm.Roborally.Server.csproj" -c Release -o /app/build

# Publish it
FROM build AS publish
RUN dotnet publish "Tgm.Roborally.Server.csproj" -c Release -o /app/publish

# Make the final image for publishing
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgm.Roborally.Server.dll"]
