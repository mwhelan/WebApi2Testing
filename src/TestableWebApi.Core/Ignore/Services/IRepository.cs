using System.Collections.Generic;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Ignore.Services
{
    public interface IRepository
    {
        #region "News Item"

        NewsItem GetNewsItem(int id);
        IEnumerable<NewsItem> GetAllNewsItems();
        bool AddNewsItem(NewsItem newsItem);
        bool UpdateNewsItem(NewsItem newsItem);

        #endregion


        #region "User Profile"
        UserProfile GetUserProfile(string userName);
        bool AddUserProfile(UserProfile userProfile);
        bool UpdateUserProfile(UserProfile userProfile);

        #endregion
    }
}