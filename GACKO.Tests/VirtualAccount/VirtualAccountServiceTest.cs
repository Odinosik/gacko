using GACKO.Services.VirtualAccount;
using GACKO.Shared.Models.VirtualAccount;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GACKO.Tests.VirtualAccount
{
    public class VirtualAccountServiceTest : BaseUnitTest
    {
        private readonly IVirtualAccountService _virtualAccountService;

        public VirtualAccountServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _virtualAccountService = scope.ServiceProvider.GetRequiredService<IVirtualAccountService>();
            }
        }

        [Fact]
        public async void IsVirtualAccountCreatePossible()
        {
            var form = new VirtualAccountForm()
            {
                Name = "",
                Balance = 50.01,
                Limit = 70,
                BankAccountId = 1,
                NotificationBalance = 20.02

            };
            var result = await _virtualAccountService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
