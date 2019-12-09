using GACKO.Services.Expense;
using GACKO.Shared.Models.Expense;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GACKO.Tests.Expense
{
    public class ExpenseServiceTest : BaseUnitTest
    {
        private readonly IExpenseService _expenseService;

        public ExpenseServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _expenseService = scope.ServiceProvider.GetRequiredService<IExpenseService>();
            }
        }

        [Fact]
        public async void IsBankAccountCreatePossible()
        {
            var form = new ExpenseForm()
            {
                Amount =20.05,
                Name ="Pączek",
                ExpenseCategoryId = 1,
                VirtualAccountId = 1
            };
            var result = await _expenseService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
