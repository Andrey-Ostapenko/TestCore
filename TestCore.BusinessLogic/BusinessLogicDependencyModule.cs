using Autofac;
using TestCore.BusinessLogic.Factories.Implementations;
using TestCore.BusinessLogic.Factories.Interfaces;
using TestCore.BusinessLogic.Service.Implementation;
using TestCore.BusinessLogic.Service.Interfaces;

namespace TestCore.BusinessLogic
{
    public class BusinessLogicDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType(typeof (UserService)).As(typeof (IUserService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (UserDtoFactory)).As(typeof (IUserDtoFactory)).InstancePerLifetimeScope();
        }
    }
}