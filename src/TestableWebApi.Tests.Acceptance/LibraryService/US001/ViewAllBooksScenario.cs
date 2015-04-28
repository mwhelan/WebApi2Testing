using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Acceptance.LibraryService.US001
{
    public class ViewAllBooksScenario : ScenarioFor<WebApiApplicationDriver>
    {
        private HttpRequestMessage _request;
        private const string BooksRelativeUri = "api/books";

        public void Given_there_are_books()
        {
        }

        public void When_I_view_the_books()
        {
            var url = new Uri(SUT.Server.BaseAddress, BooksRelativeUri);
            _request = new HttpRequestMessage(HttpMethod.Get, url);
            SUT.HandleRequest(_request);
        }

        public void Then_I_see_all_the_books()
        {
            SUT.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        public override Type Story
        {
            get { return typeof (ManageBookInventoryStory); }
        }

        public override string Title
        {
            get { return "Librarian can view Books"; }
        }

        public override int ScenarioNumber
        {
            get { return 1; }
        }
    }
}