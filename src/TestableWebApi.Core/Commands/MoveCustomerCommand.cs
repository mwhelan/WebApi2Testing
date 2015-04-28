namespace TestableWebApi.Core.Commands
{
    public class MoveCustomerCommand
    {
        public int CustomerId { get; set; }

        public string NewAddress { get; set; }
    }
}