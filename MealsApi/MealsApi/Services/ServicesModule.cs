using Autofac;

namespace MealsApi.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MealService>().As<IMealService>().InstancePerLifetimeScope();
        }
    }
}