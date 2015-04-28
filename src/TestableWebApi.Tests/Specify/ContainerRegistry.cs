using System.Collections.Concurrent;
using System.Threading;
using Autofac;

namespace TestableWebApi.Tests.Specify
{
    public static class ContainerRegistry
    {
        private static ConcurrentDictionary<int, IContainer> _registry = new ConcurrentDictionary<int, IContainer>();

        public static IContainer Get()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            return _registry[threadId];
        }

        public static void Register(IContainer container)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            _registry.TryAdd(threadId, container);
        }
    }
}