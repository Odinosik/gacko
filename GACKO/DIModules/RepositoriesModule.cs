using Autofac;
using AutoMapper;
using GACKO.Repositories.User;

namespace GACKO.DIModules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserRepository(c.Resolve<IMapper>()))
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
