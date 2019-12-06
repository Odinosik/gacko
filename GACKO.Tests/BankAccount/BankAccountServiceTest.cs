using GACKO.Services.BankAccount;
using GACKO.Shared.Models.BankAccount;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GACKO.Tests.BankAccount
{
    public class BankAccountServiceTest : BaseUnitTest
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _bankAccountService = scope.ServiceProvider.GetRequiredService<IBankAccountService>();
            }
        }

        [Fact]
        public async void IsBankAccountCreatePossible()
        {
            var form = new BankAccountForm()
            {
                Iban = "",
                Balance = 100.01,
                UserId = 100
            };
            var result = await _bankAccountService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
