using NUnit.Framework;
using TestableWebApi.Tests.Servers;

namespace TestableWebApi.Tests.Tests
{
    [TestFixture]
    public class InMemoryValueTests : ValueTests
    {
        public InMemoryValueTests() :base (new InMemoryApiServer())
        {
        }
    }
}