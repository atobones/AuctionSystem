FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY AuctionSystem.sln ./
COPY AuctionSystem.csproj ./
RUN dotnet restore

# Копируем остальные файлы и строим проект
COPY . .
WORKDIR /src

# Проверка наличия всех пакетов
RUN dotnet restore --no-cache

# Собираем проект с правильной конфигурацией
RUN dotnet build --no-restore -c Release AuctionSystem.csproj
RUN ls -la /src/bin/Release/net8.0
RUN dotnet publish --no-restore -c Release -o /app/publish AuctionSystem.csproj
RUN ls -la /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "AuctionSystem.dll"]

