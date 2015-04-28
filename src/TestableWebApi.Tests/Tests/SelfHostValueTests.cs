using NUnit.Framework;
using TestableWebApi.Tests.Servers;

namespace TestableWebApi.Tests.Tests
{
    [TestFixture]
    public class SelfHostValueTests : ValueTests
    {
        public SelfHostValueTests()
            : base(new SelfHostApiServer())
        {
        }
    }
}