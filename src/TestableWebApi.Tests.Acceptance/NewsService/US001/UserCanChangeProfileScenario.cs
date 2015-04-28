using System;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Acceptance.NewsService.US001
{
    public class UserCanChangeProfileScenario : ScenarioFor<WebApiApplicationDriver> 
    {
        public void Given_that_I_am_a_User()
        {
            throw new NotImplementedException();
        }

        public void AndGiven_I_have_an_existing_Profile()
        {
            throw new NotImplementedException();
        }

        public void When_I_change_my_Profile_details()
        {
            throw new NotImplementedException();
        }

        public void Then_my_Profile_is_updated_with_the_new_information()
        {
            throw new NotImplementedException();
        }

        public override Type Story
        {
            get { return typeof(AuthenticatedUserCanChangeTheirProfileStory); }
        }

        public override int ScenarioNumber
        {
            get { return 2; }
        }

        public override string Title
        {
            get { return "User can change Profile"; }
        }

    }
}
