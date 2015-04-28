using System;

namespace TestableWebApi.Tests.Specify
{
    public abstract class SpecificationFor<T> : Specification
    {
        public T SUT { get; set; }
        protected AutoMockingContainer<T> Resolver;

        protected SpecificationFor()
        {
            Resolver = new AutoMockingContainer<T>();
            InitialiseSystemUnderTest();
        }

        public virtual void InitialiseSystemUnderTest()
        {
            SUT = Resolver.SUT;
        }

        public TSubstitute SubFor<TSubstitute>() where TSubstitute : class
        {
            return Resolver.SubFor<TSubstitute>();
        }

        public override Type Story
        {
            get { return typeof(T); }
        }

        //private static AutoSubstitute CreateContainer()
        //{
        //    Action<ContainerBuilder> autofacCustomisation = c => c
        //        .RegisterType<T>()
        //        .FindConstructorsWith(t =>  t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        //        .PropertiesAutowired();
        //    return new AutoSubstitute(autofacCustomisation);
        //}
    }
}
