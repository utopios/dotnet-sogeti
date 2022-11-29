#Image 1 du build
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN #dotnet build -o /app/build
RUN dotnet publish -c Release -o bin
#RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /app/bin .
CMD ["dotnet", "ApiCashRegistry.dll"] 