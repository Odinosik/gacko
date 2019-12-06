using GACKO.Services.Subscription;
using GACKO.Shared.Models.Subscription;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GACKO.Tests.Subscription
{
    public class SubscriptionServiceTest : BaseUnitTest
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _subscriptionService = scope.ServiceProvider.GetRequiredService<ISubscriptionService>();
            }
        }

        [Fact]
        public async void IsBankAccountCreatePossible()
        {
            var form = new SubscriptionForm()
            {
                Name = "Internet",
                Amount = 15.20,
                AddedDate = DateTime.Now,
                ExpirationDate = DateTime.Now,
                FrequncyMonth = 3,
                VirtualAccountId = 1,
            };
            var result = await _subscriptionService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
