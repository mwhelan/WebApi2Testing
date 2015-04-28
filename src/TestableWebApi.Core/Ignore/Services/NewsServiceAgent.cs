using System.Collections.Generic;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Ignore.Services
{
    public class NewsServiceAgent : INewsServiceAgent
    {

        private NewsServiceAgent() { }

        private ISecurityManager _securityManager;

        private IRepository _repository;


        //Get Security Manager and Repository components injected into this component
        public NewsServiceAgent(ISecurityManager securityManager, IRepository repository)
        {
            _securityManager = securityManager;
            _repository = repository;
        }


        /// <summary>
        /// Request news item from datastore layer
        /// </summary>
        /// <param name="id">id of news item as asked for</param>
        /// <returns></returns>
        public NewsItem GetNewsItem(int id)
        {

            return _repository.GetNewsItem(id);

        }

        /// <summary>
        /// Request all the news items from data store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NewsItem> GetAllNewsItems()
        {

            return _repository.GetAllNewsItems();
        }

        /// <summary>
        /// Put news item in datastore 
        /// </summary>
        /// <param name="newsitem"></param>
        /// <returns></returns>
        public bool AddNewsItem(NewsItem newsitem)
        {
            //Get current logged in user name and overwrite it in news item
            newsitem.UserName = _securityManager.GetAuthenticatedUserName();

            return _repository.AddNewsItem(newsitem);
        }


        /// <summary>
        /// Update news item in datastore 
        /// </summary>
        /// <param name="newsitem"></param>
        /// <returns></returns>
        public bool UpdateNewsItem(NewsItem newsitem)
        {
            //Get current logged in user name and overwrite it in news item

            newsitem.UserName = _securityManager.GetAuthenticatedUserName();
            return _repository.UpdateNewsItem(newsitem);
        }


    }
}