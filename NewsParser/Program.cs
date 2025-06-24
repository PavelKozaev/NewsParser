using HtmlAgilityPack;
using NewsParser.Services;

var logFilePath = "log.txt";
var newsFilePath = "news.json";
var sampleNewsFilePath = "sample-news.html";

var logger = new FileLogger(logFilePath);
var htmlParser = new HtmlParser();
var newsFilter = new NewsFilter();
var jsonExporter = new JsonExporter();

try
{
    logger.Log(@$"Start of parsing news from DailyChronicle.net");

    var doc = new HtmlDocument();
    doc.Load(sampleNewsFilePath);

    var newsItems = htmlParser.ParseNews(doc, logger, out int skippedDueToParsing);

    var filteredNews = newsFilter.FilterByLast30Days(newsItems, logger, out int skippedDueToDate);

    jsonExporter.ExportToFile(filteredNews, newsFilePath);

    logger.Log($"End of parsing news from DailyChronicle.net");

    Console.WriteLine("Обработка завершена:");
    Console.WriteLine($"- Всего новостей найдено: {newsItems.Count + skippedDueToParsing}");
    Console.WriteLine($"- Успешно распознано: {newsItems.Count}");
    Console.WriteLine($"- Пропущено из-за ошибок парсинга: {skippedDueToParsing}");
    Console.WriteLine($"- После фильтрации по дате: {filteredNews.Count}");
    Console.WriteLine($"- Пропущено (устаревшие): {skippedDueToDate}");
    Console.WriteLine($"Результаты сохранены в news.json");
    Console.WriteLine($"Ошибки записаны в log.txt");
}
catch (Exception ex)
{
    logger.Log($"Fatal error: {ex.Message}");
    Console.WriteLine($"Возникла ошибка: {ex.Message}");
    Console.WriteLine("Дополнительная информация доступна в log.txt");
}
