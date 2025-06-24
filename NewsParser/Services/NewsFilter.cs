using NewsParser.Interfaces;
using NewsParser.Models;

namespace NewsParser.Services
{
    public class NewsFilter
    {
        public List<NewsItem> FilterByLast30Days(List<NewsItem> newsItems, ILogger logger, out int filteredCount)
        {
            filteredCount = 0;
            var result = new List<NewsItem>();
            var cutoffDate = DateTime.Now.AddDays(-30);

            foreach (var item in newsItems)
            {
                if (DateTime.TryParse(item.Date, out var newsDate))
                {
                    if (newsDate >= cutoffDate)
                    {
                        result.Add(item);
                    }
                    else
                    {
                        filteredCount++;
                    }
                }
                else
                {
                    logger.Log($"Invalid date format in filtered item: {item.Date}");
                    filteredCount++;
                }
            }

            return result;
        }
    }
}
