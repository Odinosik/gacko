using Autofac;
using AutoMapper;
using GACKO.DB.DaoModels;
using GACKO.Repositories.BankAccount;
using GACKO.Repositories.Expense;
using GACKO.Repositories.ExpenseCategory;
using GACKO.Repositories.SalesDocument;
using GACKO.Repositories.Subscription;
using GACKO.Repositories.VirtualAccount;
using GACKO.Services.BankAccount;
using GACKO.Services.Expense;
using GACKO.Services.ExpenseCategory;
using GACKO.Services.SalesDocument;
using GACKO.Services.Subscription;
using GACKO.Services.User;
using GACKO.Services.VirtualAccount;
using Microsoft.AspNetCore.Identity;

namespace GACKO.DIModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserService(c.Resolve<UserManager<DaoUser>>(),
                    c.Resolve<SignInManager<DaoUser>>(),
                    c.Resolve<IMapper>()))
                .As<IUserService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new SalesDocumentService(c.Resolve<ISalesDocumentRepository>(),
                    c.Resolve<IExpenseRepository>()))
                .As<ISalesDocumentService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseCategoryService(c.Resolve<IExpenseCategoryRepository>()))
                .As<IExpenseCategoryService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ExpenseService(c.Resolve<IExpenseRepository>(), 
                    c.Resolve<ISalesDocumentRepository>()))
                .As<IExpenseService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new SubscriptionService(c.Resolve<ISubscriptionRepository>()))
                .As<ISubscriptionService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new VirtualAccountService(c.Resolve<IVirtualAccountRepository>(), 
                    c.Resolve<IExpenseService>(), c.Resolve<ISubscriptionService>()))
                .As<IVirtualAccountService>()
                .InstancePerLifetimeScope();

            builder.Register(c => new BankAccountService(c.Resolve<IBankAccountRepository>()))
                .As<IBankAccountService>()
                .InstancePerLifetimeScope();
        }
    }
}
