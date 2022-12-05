FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["pokemon-blazor/pokemon-blazor.csproj", "pokemon-blazor/"]
RUN dotnet restore "pokemon-blazor/pokemon-blazor.csproj"
COPY . .
WORKDIR "/src/pokemon-blazor"
RUN dotnet build "pokemon-blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pokemon-blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pokemon-blazor.dll"]
