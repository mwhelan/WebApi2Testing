using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using TestableWebApi.Core.Ignore.Services;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Api.Handlers
{
    public class RequireHttpsMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                HttpResponseMessage forbiddenResponse =
                    request.CreateResponse(HttpStatusCode.Forbidden);

                forbiddenResponse.ReasonPhrase = "SSL Required";
                return Task.FromResult<HttpResponseMessage>(forbiddenResponse);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }

    public class SecurityManager : DelegatingHandler, ISecurityManager
    {

        private IRepository _repository;
        private const string RANDOMKEY = "|%(wQag3|";

        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        //todo , remove these after data store is setup
        private const string Username = "username";
        private const string Password = "password";

        // Set property for dependency 
        public IRepository Repository
        {
            set
            {
                _repository = value;
            }
        }

        /// <summary>
        /// Create a local principal value
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public IPrincipal CreatePrincipal(string userName, string password)
        {
            // todo, enable this after data store is setup

            //find user in data store
            var userProfile = _repository.GetUserProfile(userName);

            if (userProfile == null)
                return null;

            //match password with one stored in data store 
            if (userProfile.UserPassword != GetHashedPassword(password + RANDOMKEY))
                return null;

            var identity = new GenericIdentity(userName + RANDOMKEY + password);

            IPrincipal principal = new GenericPrincipal(identity, new[] { "User" });
            return principal;
        }


        /// <summary>
        /// Intercept incomming HTTP headers and check for authentication
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue authValue = request.Headers.Authorization;
            if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter))
            {
                Credentials parsedCredentials = ParseAuthorizationHeader(authValue.Parameter);
                if (parsedCredentials != null)
                {
                    Thread.CurrentPrincipal =
                        CreatePrincipal(parsedCredentials.Username, parsedCredentials.Password);
                }
            }
            return base.SendAsync(request, cancellationToken)
               .ContinueWith(task =>
               {
                   var response = task.Result;
                   if (response.StatusCode == HttpStatusCode.Unauthorized
                       && !response.Headers.Contains(BasicAuthResponseHeader))
                   {
                       response.Headers.Add(BasicAuthResponseHeader
                           , BasicAuthResponseHeaderValue);
                   }
                   return response;
               });
        }

        /// <summary>
        /// Parse Authorise header for authentication values
        /// </summary>
        /// <param name="authHeader"></param>
        /// <returns></returns>
        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.ASCII.GetString(Convert
                                                            .FromBase64String(authHeader))
                                                            .Split(
                                                            new[] { ':' });
            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0])
                || string.IsNullOrEmpty(credentials[1])) return null;
            return new Credentials()
            {
                Username = credentials[0],
                Password = credentials[1],
            };
        }

        /// <summary>
        /// Authenticate user against stored principal data
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public bool AuthenticateUser(UserProfile userProfile)
        {
            if (userProfile == null)
                return false;

            var currentIdentity = Thread.CurrentPrincipal.Identity.Name;

            //Make sure that user is same by checking stored identity and user profile values
            return currentIdentity == userProfile.UserName + RANDOMKEY + userProfile.UserPassword;

        }

        /// <summary>
        /// Get name of authenticated user from principal or return null if not setup
        /// </summary>
        /// <returns></returns>
        public string GetAuthenticatedUserName()
        {
            if (!String.IsNullOrEmpty(Thread.CurrentPrincipal.Identity.Name))
            {
                var identityValues = Thread.CurrentPrincipal.Identity.Name.Split('|');
                return identityValues[0];
            }
            else
            {
                return null;
            }
        }

        public string GetHashedPassword(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }


        #region Static Methods
        // HTTPS enforcement if this is a release version
        public static void VerifyHttpsAccess(HttpActionContext actionContext)
        {
#if !DEBUG
            if (!String.Equals(actionContext.Request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("HTTPS Required")
                };
                return;

            }
#endif

        }

        #endregion
    }
}