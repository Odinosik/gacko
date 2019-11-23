using Autofac;
using AutoMapper;
using System;
using System.Linq;
using GACKO.Shared.AutoMapperProfiles;

namespace GACKO.DIModules
{
    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var profiles =
                from t in typeof(AutoMapperProfile).Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(t)
                select (Profile)Activator.CreateInstance(t);

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}
