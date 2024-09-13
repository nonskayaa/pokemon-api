# Pokémon API

Этот проект представляет собой API для покемонов, разработанное с использованием .NET 8 и базы данных SQLite. 

## Содержание

- [Описание](#описание)
- [Установка](#установка)
- [Запуск](#запуск)
- [API Эндпоинты](#api-эндпоинты)

## Описание

Этот API позволяет взаимодействовать с данными о покемонах, предоставляя возможности для выполнения различных операций, таких как получение списка покемонов, добавление новых и обновление существующих.

## Установка

### Предварительные требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQLite](https://www.sqlite.org/download.html) (или любой другой клиент SQLite)

### Клонирование репозитория

1. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/nonskayaa/pokemon-api

2. Перейдите в директорию проекта:

### Установка зависимостей

1. Установите все необходимые пакеты:
   ```bash
   dotnet restore

2. Примените миграции для создания базы данных: 
   ```bash
   dotnet ef database update
   
## Запуск

1. Запустите проект:
   ```bash
   dotnet run

2. API будет доступно по умолчанию по адресу http://localhost:5041 или можно посмотреть с помощью Swagger UI по адресу http://localhost:5041/swagger

## API Эндпоинты

1. GET /api/pokemons - Получить список всех покемонов
2. GET /api/pokemons/{id} - Получить информацию о конкретном покемоне по ID
3. POST /api/pokemons - Добавить нового покемона
4. DELETE /api/pokemons/{id} - Удалить покемона