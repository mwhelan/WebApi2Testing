using System;
using System.Linq;

namespace TestableWebApi.Tests.Specify
{
    using TestStack.BDDfy;

    public class StoryMetadataScanner : IStoryMetadataScanner
    {
        public virtual StoryMetadata Scan(object testObject, Type explicityStoryType = null)
        {
            var scenario = testObject as ISpecification;
            if (scenario == null)
                return null;

            var storyAttribute = GetStoryAttribute(scenario.Story);
            if (storyAttribute == null)
                return null;

            return new StoryMetadata(scenario.Story, storyAttribute);
        }

        static StoryAttribute GetStoryAttribute(Type candidateStoryType)
        {
            return (StoryAttribute)candidateStoryType.GetCustomAttributes(typeof(StoryAttribute), true).FirstOrDefault();
        }
    }
}
