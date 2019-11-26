using Autofac;
using AutoMapper;
using GACKO.DB;
using GACKO.Repositories.BankAccount;
using GACKO.Repositories.User;
using GACKO.Shared;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}
