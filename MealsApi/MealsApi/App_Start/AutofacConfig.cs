using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using MealsApi.Utils.Autofac;

namespace MealsApi.App_Start
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(AutofacConfig).Assembly);

            RegisterDependencies(builder);
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            RegisterModules(builder, assemblies);
            AutowireProperties(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());


            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacResolver(Container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
        }

        private static void AutowireProperties(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(ThisAssembly).Assembly)
                .PropertiesAutowired();

            builder.RegisterType<WebApiApplication>()
                .PropertiesAutowired();
        }

        private static void RegisterModules(ContainerBuilder builder, Assembly[] assemblies)
        {
            // register modules from assemblies
            builder.RegisterAssemblyModules(assemblies);
        }
    }
}