﻿namespace TestableWebApi.Core.Commands
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
