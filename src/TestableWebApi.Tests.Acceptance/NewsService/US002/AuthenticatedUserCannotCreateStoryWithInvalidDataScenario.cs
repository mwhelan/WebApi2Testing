using System;
using TestableWebApi.Tests.Servers;
using TestableWebApi.Tests.Specify;

namespace TestableWebApi.Tests.Acceptance.NewsService.US002
{
    public class AuthenticatedUserCannotCreateStoryWithInvalidDataScenario : ScenarioFor<WebApiApplicationDriver> 
    {
        public void Given_that_I_am_an_Authenticated_User()
        {
            throw new NotImplementedException();
        }

        public void AndGiven_I_have_input_a_News_Story_without_a_Title_or_Content_Body()
        {
            throw new NotImplementedException();
        }

        public void When_I_create_the_News_Story()
        {
            throw new NotImplementedException();
        }

        public void Then_the_News_Story_is_not_added()
        {
            throw new NotImplementedException();
        }

        public void AndThen_I_am_told_that_the_News_Story_was_not_added()
        {
            throw new NotImplementedException();
        }

        public void AndThen_I_am_given_a_message_explaining_what_the_problem_was_()
        {
            throw new NotImplementedException();
        }

        public override Type Story
        {
            get { return typeof(AuthenticatedUserCanCreateNewsStory); }
        }

        public override int ScenarioNumber
        {
            get { return 1; }
        }

        public override string Title
        {
            get { return "Authenticated User cannot create Story with invalid data"; }
        }
    }
}
