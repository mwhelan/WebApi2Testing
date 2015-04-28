using System;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Acceptance.NewsService.US001
{
    public class UserCanLoginScenario : ScenarioFor<WebApiApplicationDriver> 
    {
        public void Given_that_I_am_an_Authenticated_User()
        {
            throw new NotImplementedException();
        }

        public void AndGiven_I_am_not_logged_in()
        {
            throw new NotImplementedException();
        }

        public void When_I_provide_my_valid_login_details_()
        {
            throw new NotImplementedException();
        }

        public void Then_I_am_logged_in_as_an_Authenticated_User()
        {
            throw new NotImplementedException();
        }

        public override Type Story
        {
            get { return typeof(AuthenticatedUserCanChangeTheirProfileStory); }
        }

        public override int ScenarioNumber
        {
            get { return 1; }
        }

        public override string Title
        {
            get { return "User can login"; }
        }
    }
}
