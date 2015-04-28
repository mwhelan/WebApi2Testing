using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace TestableWebApi.Tests.Specify
{
    public class IocContainer<TSut> : IResolver<TSut>
    {
        public TSut SUT { get; private set; }
        public T Resolve<T>(params Parameter[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AutofacDependencyScope<TSut> : IResolver<TSut>
	{
		private ILifetimeScope scope;

		public AutofacDependencyScope(ILifetimeScope scope)
		{
			if (scope == null)
				throw new ArgumentNullException("scope");

			this.scope = scope;
		}

		public object GetService(Type serviceType)
		{
			if (scope == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed.");

			if (!scope.IsRegistered(serviceType))
				return null;

			return scope.Resolve(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			if (scope == null)
				throw new ObjectDisposedException("this", "This scope has already been disposed.");

			if (!scope.IsRegistered(serviceType))
                return Enumerable.Empty<object>();

			return (IEnumerable<object>) scope.Resolve(typeof (IEnumerable<>).MakeGenericType(serviceType));
		}

    	public void Dispose()
    	{
			scope.Dispose();
    		scope = null;
    	}

        public TSut SUT { get; private set; }
        public T Resolve<T>(params Parameter[] parameters)
        {
            throw new NotImplementedException();
        }
	}

    public class AutofacResolver<TSut> : AutofacDependencyScope<TSut>, IResolver<TSut>
    {
        private readonly IContainer container;

        public AutofacResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IResolver<TSut> BeginScope()
        {
            return new AutofacDependencyScope<TSut>(container.BeginLifetimeScope());
        }

        public TSut SUT { get; private set; }

        public T Resolve<T>(params Parameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}