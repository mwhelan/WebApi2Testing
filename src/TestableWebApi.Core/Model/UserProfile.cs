namespace TestableWebApi.Core.Model
{
    public class UserProfile
    {
        public string UserName { get; set; }                //used as primary / unique key to identify
        //[JsonIgnore]
        public string UserPassword { get; set; }
        public string FriendlyName { get; set; }
        public string ProfileText { get; set; }
    }
}