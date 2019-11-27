using GACKO_MVC;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GACKO.Test
{
    //[assembly: CollectionBehavior(DisableTestParallelization = true)]
    public class BaseUnitTest : IClassFixture<GackoWebApplicationFactory<Startup>>
    {
        protected readonly GackoWebApplicationFactory<Startup> _factory;

        public BaseUnitTest(GackoWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
    }
}
