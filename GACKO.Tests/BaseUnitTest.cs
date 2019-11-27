using Xunit;

namespace GACKO.Tests
{
    //[assembly: CollectionBehavior(DisableTestParallelization = true)]
    public class BaseUnitTest : IClassFixture<GackoWebApplicationFactory<TestStartup>>
    {
        protected readonly GackoWebApplicationFactory<TestStartup> _factory;

        public BaseUnitTest(GackoWebApplicationFactory<TestStartup> factory)
        {
            _factory = factory;
        }
    }
}
