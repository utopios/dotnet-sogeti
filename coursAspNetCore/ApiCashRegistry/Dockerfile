FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build -o /app/build