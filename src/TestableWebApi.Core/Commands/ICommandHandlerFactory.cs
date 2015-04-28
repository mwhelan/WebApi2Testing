namespace TestableWebApi.Core.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> HandlerForCommand<T>(T command);
    }
}