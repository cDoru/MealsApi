using System.Web.Hosting;
using Autofac;

namespace MealsApi.Services
{
    /// <summary>
    /// Module responsible of registering all the services
    /// </summary>
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MealService>().As<IMealService>().InstancePerLifetimeScope();
            builder.Register<IFileSystem>(x => new FileSystem
            {
                GetFilePathFunc = filePath =>
                {
                    var mapPath = HostingEnvironment.MapPath("~/App_Data");
                    return mapPath != null ? string.Format("{0}/{1}", mapPath.Replace("\\", "/"), filePath) : null;
                }
            });

            builder.RegisterType<Configuration>().As<IConfiguration>().InstancePerLifetimeScope();
            builder.RegisterType<Encryptor>().As<IEncryptor>().InstancePerLifetimeScope();
            builder.RegisterType<ImageService>().As<IImageService>().InstancePerLifetimeScope();
        }
    }
}