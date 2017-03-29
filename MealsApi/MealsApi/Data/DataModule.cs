using Autofac;
using MealsApi.Data.Contracts;
using MealsApi.Utils.Ef;

namespace MealsApi.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SequentialGuidGenerator>().As<IGuidGenerator>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseContext>().As<IDatabaseContext>().InstancePerLifetimeScope();
        }
    }
}