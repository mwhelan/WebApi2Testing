using System;
using Autofac;
using NSubstitute.Core;

namespace TestableWebApi.Tests.Specify
{
    public abstract class ScenarioFor<T> : Specification 
    {
        public T SUT { get; set; }
        public IContainer Container { get; private set; }

        public ScenarioFor()
        {
            Container = ContainerRegistry.Get();
            InitialiseSystemUnderTest();
        }

        public virtual void InitialiseSystemUnderTest()
        {
            SUT = Container.Resolve<T>();
        }

        public abstract override Type Story { get; } 
        public abstract int ScenarioNumber { get; }
        public abstract override string Title { get; }

        protected override string BuildTitle()
        {
            return string.Format("Scenario {0}: {1}", ScenarioNumber.ToString("00"), Title);
        }
    }
}