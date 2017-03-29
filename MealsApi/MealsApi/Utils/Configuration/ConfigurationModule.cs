using Autofac;

namespace MealsApi.Utils.Configuration
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Configuration>().As<IConfiguration>().InstancePerLifetimeScope();
        }
    }
}