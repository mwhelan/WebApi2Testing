using Autofac.Core;

namespace TestableWebApi.Tests.Specify
{
    public interface IResolver<TSut>
    {
        TSut SUT { get; }
        T Resolve<T>(params Parameter[] parameters);
    }
}