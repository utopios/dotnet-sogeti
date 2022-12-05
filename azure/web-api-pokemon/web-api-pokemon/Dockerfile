FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["web-api-pokemon/web-api-pokemon.csproj", "web-api-pokemon/"]
RUN dotnet restore "web-api-pokemon/web-api-pokemon.csproj"
COPY . .
WORKDIR "/src/web-api-pokemon"
RUN dotnet build "web-api-pokemon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "web-api-pokemon.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "web-api-pokemon.dll"]
