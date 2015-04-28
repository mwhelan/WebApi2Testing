using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Ignore.Services
{
    public interface ISecurityManager
    {
        bool AuthenticateUser(UserProfile userProfile);

        string GetAuthenticatedUserName();

        string GetHashedPassword(string input);
    }
}