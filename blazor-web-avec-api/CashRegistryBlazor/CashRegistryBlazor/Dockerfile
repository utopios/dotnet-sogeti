FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CashRegistryBlazor/CashRegistryBlazor.csproj", "CashRegistryBlazor/"]
RUN dotnet restore "CashRegistryBlazor/CashRegistryBlazor.csproj"
COPY . .
WORKDIR "/src/CashRegistryBlazor"
RUN dotnet build "CashRegistryBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashRegistryBlazor.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
#ENTRYPOINT ["dotnet", "CashRegistryBlazor.dll"]
