namespace TestableWebApi.Core.Commands
{
    public class MoveCustomerCommandHandler : ICommandHandler<MoveCustomerCommand>
    {
        private readonly ICustomerRepository _repository;

        public MoveCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Handle(MoveCustomerCommand command)
        {
            // TODO: Logic here
        }
    }
}