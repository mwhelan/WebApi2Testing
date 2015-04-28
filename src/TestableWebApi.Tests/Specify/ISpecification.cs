using System;

namespace TestableWebApi.Tests.Specify
{
    public interface ISpecification
    {
        Type Story { get; }
        string Title { get; set; }
    }
}