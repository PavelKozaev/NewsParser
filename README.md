# NewsParser

https://img.shields.io/badge/.NET-8.0-blue
https://img.shields.io/badge/HtmlAgilityPack-1.11.46-green
https://img.shields.io/badge/System.Text.Json-8.0-blue

**DailyChronicleParser** — консольное приложение для парсинга новостей с сайта DailyChronicle.net и сохранения их в JSON-формате.

## 🚀 Быстрый старт
Склонируйте репозиторий
```bash
git clone https://github.com/PavelKozaev/DailyChronicleParser.git
```
Перейдите в корневую папку решения
```bash
cd DailyChronicleParser
```
Запустите приложение
```bash
dotnet run
```

## 📌 Основные возможности
- Парсинг HTML-страницы с новостями
- Извлечение заголовков, ссылок и дат публикации
- Фильтрация новостей за последние 30 дней
- Сохранение результатов в JSON-файл
- Логирование начала, окончания парсинга и ошибок в файл
- Статистика обработки новостей

## 📋 Требования
- NET 9 SDK
- Файл с HTML-контентом (sample-news.html) в папке с исполняемым файлом

## 🛠 Инструкция по запуску
- Поместите HTML-файл с новостями (например, sample-news.html) в папку bin/Debug/net8.0/
- Запустите приложение:
```bash
dotnet run
```
- После выполнения будут созданы файлы:
news.json - результат парсинга в JSON-формате
log.txt - журнал начала, окончания парсинга и ошибок
- Результаты работы отобразятся в консоли:
```bash
Обработка завершена:
- Всего новостей найдено: 10
- Успешно распознано: 8
- Пропущено из-за ошибок парсинга: 2
- После фильтрации по дате: 5
- Пропущено (устаревшие): 3
Результаты сохранены в news.json
Ошибки записаны в log.txt
```

## Пример выходного JSON
```bash
[
  {
    "title": "Environmental Summit 2025",
    "url": "https://dailychronicle.net/world/environmental-summit",
    "date": "2025-06-22"
  },
  {
    "title": "Elections 2025: What's New",
    "url": "https://dailychronicle.net/politics/elections-update",
    "date": "2025-06-20"
  }
]
```

## Контрибьютинг

Если вы хотите внести свой вклад в проект, пожалуйста, создайте форк репозитория, создайте новую ветку, внесите свои изменения и отправьте pull request.

## Лицензия

Данный проект не лицензирован.

## Автор

[Pavel Kozaev](https://github.com/PavelKozaev)
