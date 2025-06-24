using HtmlAgilityPack;
using NewsParser.Interfaces;
using NewsParser.Models;

namespace NewsParser.Services
{
    public class HtmlParser
    {
        public List<NewsItem> ParseNews(HtmlDocument doc, ILogger logger, out int skippedCount)
        {
            var newsItems = new List<NewsItem>();
            var baseUrl = "https://dailychronicle.net";
            skippedCount = 0;

            var newsNodes = doc.DocumentNode.SelectNodes("//ul[@class='news-list']/li[@class='news-item']");

            if (newsNodes is null)
            {
                logger.Log("No news items found in the HTML document.");
                return newsItems;
            }

            foreach (var node in newsNodes)
            {
                try
                {
                    var titleNode = node.SelectSingleNode(".//h4[@class='news-title']/a");
                    var timeNode = node.SelectSingleNode(".//time");

                    if (titleNode is null || timeNode is null)
                    {
                        skippedCount++;
                        continue;
                    }

                    var title = titleNode.InnerText.Trim();
                    var relativeUrl = titleNode.GetAttributeValue("href", "");
                    var dateString = timeNode.GetAttributeValue("datetime", "");

                    if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(relativeUrl) || string.IsNullOrEmpty(dateString))
                    {
                        skippedCount++;
                        continue;
                    }

                    var absoluteUrl = $"{baseUrl}{relativeUrl}";

                    if (!DateTime.TryParse(dateString, out var date))
                    {
                        logger.Log($"Invalid date format: {dateString}");
                        skippedCount++;
                        continue;
                    }

                    newsItems.Add(new NewsItem
                    {
                        Title = title,
                        Url = absoluteUrl,
                        Date = date.ToString("yyyy-MM-dd")
                    });
                }
                catch (Exception ex)
                {
                    logger.Log($"Error parsing news item: {ex.Message}");
                    skippedCount++;
                }
            }

            return newsItems;
        }
    }
}
