# Используем официальный образ для .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и собираем проект
COPY . ./
RUN dotnet publish -c Release -o out

# Используем более легкий runtime образ для выполнения приложения
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Устанавливаем порт для запуска
EXPOSE 80

# Запуск приложения
ENTRYPOINT ["dotnet", "Ваше_Приложение.dll"]
