using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using TestableWebApi.Core.Ignore.Services;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Api.Controllers
{
    public class NewsController : ApiController
    {
        private INewsServiceAgent _newsServiceAgent;

        public NewsController(INewsServiceAgent newsServiceAgent)
        {
            _newsServiceAgent = newsServiceAgent;
        }

        // GET api/news
        [AllowAnonymous]
        public IEnumerable<NewsItem> Get()
        {
            return _newsServiceAgent.GetAllNewsItems();

        }

        // GET api/news/5
        [AllowAnonymous]
        public NewsItem Get(int id)
        {
            return _newsServiceAgent.GetNewsItem(id);
        }

        // POST api/news
        [Authorize]
        public HttpResponseMessage Post(NewsItem newsItem)
        {
            var currentDate = System.DateTime.Now;

            var news = new NewsItem { Id = -1, Title = newsItem.Title, Body = newsItem.Body, CreatedDate = currentDate, ExpiryDate = currentDate.AddDays(20), PublishDate = currentDate };

            if (_newsServiceAgent.AddNewsItem(news))
            {

                return (new HttpResponseMessage(System.Net.HttpStatusCode.Created));
            }

            return (new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));
        }

        // PUT api/news/5
        [HttpPost]
        [Authorize]
        public void Put(int id, [FromBody]NewsItem newsItem)
        {
            newsItem.Id = id;
            _newsServiceAgent.UpdateNewsItem(newsItem);
        }

    }
}
