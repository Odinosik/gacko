using Autofac;
using AutoMapper;
using GACKO.Repositories.BankAccount;
using GACKO.Repositories.Expense;
using GACKO.Repositories.ExpenseCategory;
using GACKO.Repositories.Subscription;
using GACKO.Repositories.User;
using GACKO.Shared;

namespace GACKO.DIModules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserRepository(c.Resolve<IMapper>()))
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new BankAccountRepository(c.Resolve<IMapper>(), c.Resolve<IDbContextOptionsFactory>()))
                .As<IBankAccountRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new SubscriptionRepository(c.Resolve<IMapper>(), c.Resolve<IDbContextOptionsFactory>()))
                .As<ISubscriptionRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseCategoryRepository(c.Resolve<IMapper>(), c.Resolve<IDbContextOptionsFactory>()))
               .As<IExpenseCategoryRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseRepository(c.Resolve<IMapper>(), c.Resolve<IDbContextOptionsFactory>()))
               .As<IExpenseRepository>()
               .InstancePerLifetimeScope();
        }
    }
}
