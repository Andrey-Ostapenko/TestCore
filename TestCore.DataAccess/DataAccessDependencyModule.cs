using Autofac;
using Microsoft.EntityFrameworkCore;
using TestCore.DataAccess.Context;
using TestCore.DataAccess.Repositories.Generic.Implementation;
using TestCore.DataAccess.Repositories.Generic.Interfaces;

namespace TestCore.DataAccess
{
    public class DataAccessDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.RegisterType<DataContext>().Named<DbContext>(Configuration["Data:DefaultConnection:ConnectionString"]).InstancePerLifetimeScope();
            //builder.RegisterType(typeof(DataContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}