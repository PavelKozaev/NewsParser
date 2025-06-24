using NewsParser.Models;
using System.Text.Json;

namespace NewsParser.Services
{
    public class JsonExporter
    {
        public void ExportToFile(List<NewsItem> newsItems, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(newsItems, options);
            File.WriteAllText(filePath, json);
        }
    }
}
