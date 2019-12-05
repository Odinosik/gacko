using Autofac;
using GACKO.Repositories.BankAccount;
using GACKO.Repositories.Expense;
using GACKO.Repositories.ExpenseCategory;
using GACKO.Repositories.Subscription;
using GACKO.Repositories.User;
using GACKO.Services.BankAccount;
using GACKO.Services.Expense;
using GACKO.Services.ExpenseCategory;
using GACKO.Services.Subscription;
using GACKO.Services.User;

namespace GACKO.DIModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserService(c.Resolve<IUserRepository>()))
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new BankAccountService(c.Resolve<IBankAccountRepository>()))
                .As<IBankAccountService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new SubscriptionService(c.Resolve<ISubscriptionRepository>()))
               .As<ISubscriptionService>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseCategoryService(c.Resolve<IExpenseCategoryRepository>()))
               .As<IExpenseCategoryService>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseService(c.Resolve<IExpenseRepository>()))
               .As<IExpenseService>()
               .InstancePerLifetimeScope();
        }
    }
}
