using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestableWebApi.Api.Controllers
{
    public class BooksController : ApiController
    {
        // GET api/books
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
