using System;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Acceptance.NewsService.US003
{
    public class UserCanViewAllTheStoriesScenario : ScenarioFor<WebApiApplicationDriver>
    {
        public void Given_that_I_am_a_User()
        {
            throw new NotImplementedException();
        }

        public void AndGiven_there_are_5_News_Stories()
        {
            throw new NotImplementedException();
        }

        public void When_I_view_the_Stories()
        {
            throw new NotImplementedException();
        }

        public void Then_I_see_all_5_Stories()
        {
            throw new NotImplementedException();
        }

        public override Type Story
        {
            get { return typeof (ViewingNewsStoriesStory); }
        }

        public override int ScenarioNumber
        {
            get { return 1; }
        }

        public override string Title
        {
            get { return "User can view all the Stories"; }
        }
    }
}
