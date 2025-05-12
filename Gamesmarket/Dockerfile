FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Gamesmarket/Gamesmarket.csproj", "Gamesmarket/"]
COPY ["Gamesmarket.DAL/Gamesmarket.DAL.csproj", "Gamesmarket.DAL/"]
COPY ["Gamesmarket.Domain/Gamesmarket.Domain.csproj", "Gamesmarket.Domain/"]
COPY ["Gamesmarket.Service/Gamesmarket.Service.csproj", "Gamesmarket.Service/"]
COPY ["Gamesmarket.Interfaces/Gamesmarket.Interfaces.csproj", "Gamesmarket.Interfaces/"]
COPY ["Gamesmarket.Utilities/Gamesmarket.Utilities.csproj", "Gamesmarket.Utilities/"]
RUN dotnet restore "./Gamesmarket/Gamesmarket.csproj"
COPY . .
WORKDIR "/src/Gamesmarket"
RUN dotnet build "./Gamesmarket.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Gamesmarket.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gamesmarket.dll"]