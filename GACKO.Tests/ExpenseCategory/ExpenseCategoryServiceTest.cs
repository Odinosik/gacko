

using GACKO.Services.ExpenseCategory;
using GACKO.Shared.Models.ExpenseCategory;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GACKO.Tests.ExpenseCategory
{
    public class ExpenseCategoryServiceTest : BaseUnitTest
    {
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryServiceTest(GackoWebApplicationFactory<TestStartup> factory) : base(factory)
        {
            using (var scope = _factory.Server.Host.Services.CreateScope())
            {
                _expenseCategoryService = scope.ServiceProvider.GetRequiredService<IExpenseCategoryService>();
            }
        }

        [Fact]
        public async void IsBankAccountCreatePossible()
        {
            var form = new ExpenseCategoryForm()
            {
                Name = "Kolacja"
            };
            var result = await _expenseCategoryService.Create(form);
            Assert.NotEqual(0, result);
        }
    }
}
