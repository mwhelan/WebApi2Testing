using System.Collections.Generic;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Ignore.Services
{
    public interface INewsServiceAgent
    {
        NewsItem GetNewsItem(int id);
        IEnumerable<NewsItem> GetAllNewsItems();
        bool AddNewsItem(NewsItem newsitem);
        bool UpdateNewsItem(NewsItem newsitem);
    }
}