# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Maxanger.Api/Maxanger.Api.csproj", "Maxanger.Api/"]
COPY ["Maxanger.Application/Maxanger.Application.csproj", "Maxanger.Application/"]
COPY ["Maxanger.Domain/Maxanger.Domain.csproj", "Maxanger.Domain/"]
COPY ["Maxanger.Console/Maxanger.Console.csproj", "Maxanger.Console/"]

RUN dotnet restore "Maxanger.Api/Maxanger.Api.csproj"

COPY . .
RUN dotnet publish "Maxanger.Api/Maxanger.Api.csproj" -c Release -o /app/publish

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Maxanger.Api.dll"]