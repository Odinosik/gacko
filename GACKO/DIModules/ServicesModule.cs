﻿using Autofac;
using AutoMapper;
using GACKO.Repositories.User;
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
        }
    }
}