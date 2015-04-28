using System;
using System.Collections.Generic;
using System.Linq;
using TestableWebApi.Core.Model;

namespace TestableWebApi.Core.Ignore.Services
{
    public class Repository : IRepository
    {
        //private static Logger _logger = LogManager.GetCurrentClassLogger();
        private static List<NewsItem> _newsItems;
        private static List<UserProfile> _userProfiles;
        private static int _nextId = 1;

        public Repository()
        {
            _newsItems = new List<NewsItem>();
            _userProfiles = new List<UserProfile>();

            var currentTime = System.DateTime.Now;

            _newsItems.Add(new NewsItem { Id = 1, Title = "First News Story", Body = "First news Story goes like this.......", ExpiryDate = currentTime.AddDays(20), PublishDate = currentTime, CreatedDate = currentTime });
            _newsItems.Add(new NewsItem { Id = 2, Title = "2ns News Story", Body = "2nd news Story goes like this.......", ExpiryDate = currentTime.AddDays(20), PublishDate = currentTime, CreatedDate = currentTime });
            _newsItems.Add(new NewsItem { Id = 3, Title = "3rd News Story", Body = "3rd news Story goes like this.......", ExpiryDate = currentTime.AddDays(20), PublishDate = currentTime, CreatedDate = currentTime });
            _userProfiles.Add(new UserProfile { UserName = "User1", FriendlyName = "Full User Name", ProfileText = "Complete Profile Goes here", UserPassword = "userpass" });
        }

        public Repository(List<NewsItem> newsItems, List<UserProfile> userProfiles)
        {
            _newsItems = newsItems;
            _userProfiles = userProfiles;

            var lastItem = newsItems.Last();

            _nextId = lastItem.Id + 1;
        }

        #region "News Item"

        public NewsItem GetNewsItem(int id)
        {
            return _newsItems.Find(n => n.Id == id);
        }

        public IEnumerable<NewsItem> GetAllNewsItems()
        {
            return _newsItems;
        }

        public bool AddNewsItem(NewsItem newsItem)
        {
            if (newsItem == null)
            {
                throw new ArgumentNullException("newsItem");
            }

            bool status = false;

            try
            {
                newsItem.Id = newsItem.Id == -1 ? _nextId++ : newsItem.Id;
                _newsItems.Add(newsItem);

                status = true;
            }
            catch (Exception ex)
            {
                //_logger.ErrorException("Add News Item Failed with exception: ", ex);
                status = false;
            }

            return status;
        }

        public bool UpdateNewsItem(NewsItem newsItem)
        {
            if (newsItem == null)
            {
                throw new ArgumentNullException("newsItem");
            }

            int index = _newsItems.FindIndex(p => p.Id == newsItem.Id);

            if (index == -1)
            {
                return false;
            }

            _newsItems.RemoveAt(index);
            _newsItems.Add(newsItem);

            return true;
        }

        public bool RemoveNewsItem(int id)
        {
            return false;
        }

        #endregion

        #region "User Profile"

        public UserProfile GetUserProfile(string userName)
        {
            return _userProfiles.Find(u => u.UserName == userName);
        }

        public bool AddUserProfile(UserProfile userProfileFull)
        {
            if (userProfileFull == null)
            {
                throw new ArgumentNullException("userProfile");
            }

            bool status = false;

            try
            {
                var userProfile = new UserProfile { UserName = userProfileFull.UserName, UserPassword = userProfileFull.UserPassword, FriendlyName = userProfileFull.FriendlyName, ProfileText = userProfileFull.ProfileText };
                _userProfiles.Add(userProfile);
                status = true;
            }
            catch (Exception ex)
            {
                //_logger.ErrorException("Add User Failed with exception: ", ex);
                status = false;
            }

            return status;
        }

        public bool UpdateUserProfile(UserProfile userProfile)
        {
            if (userProfile == null)
            {
                throw new ArgumentNullException("userProfile");
            }

            int index = _userProfiles.FindIndex(p => p.UserName == userProfile.UserName);

            if (index == -1)
            {
                return false;
            }

            _userProfiles.RemoveAt(index);
            _userProfiles.Add(userProfile);

            return true;
        }

        public bool RemoveUserProfile(string userName)
        {
            return false;
        }

        #endregion
    }
}