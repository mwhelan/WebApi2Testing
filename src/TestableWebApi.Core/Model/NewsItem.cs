using System;

namespace TestableWebApi.Core.Model
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //[JsonIgnore]
        public string UserName { get; set; }
        //[JsonIgnore]
        public DateTime PublishDate { get; set; }
        //[JsonIgnore]
        public DateTime CreatedDate { get; set; }
        //[JsonIgnore]
        public DateTime ExpiryDate { get; set; }
        //[JsonIgnore]
        //public eNewsAccessLevel? AccessLevel { get; set; }
    }
}
