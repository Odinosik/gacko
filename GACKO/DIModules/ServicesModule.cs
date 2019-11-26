using Autofac;
using GACKO.Repositories.BankAccount;
using GACKO.Repositories.User;
using GACKO.Services.BankAccount;
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
        }
    }
}
