namespace TestableWebApi.Core.Queries
{
    public class FindUserBySearchTextQuery : IQuery<User[]>
    {
        public string SearchText { get; set; }
        public bool IncludeInactiveUsers { get; set; }
    }
}