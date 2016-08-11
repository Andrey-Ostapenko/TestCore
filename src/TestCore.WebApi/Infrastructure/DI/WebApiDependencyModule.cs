using Autofac;
using AutoMapper;
using TestCore.WebApi.Factories.Implementations;
using TestCore.WebApi.Factories.Interfaces;
using TestCore.WebApi.Mappings;

namespace TestCore.WebApi.Infrastructure.DI
{
    public class WebApiDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType(typeof (UserFactory)).As(typeof (IUserFactory)).InstancePerLifetimeScope();
            builder.Register(ctn => AutoMapperConfig.Configure()).SingleInstance();
            builder.Register(ctn => ctn.Resolve<MapperConfiguration>().CreateMapper()).SingleInstance();
        }
    }
}