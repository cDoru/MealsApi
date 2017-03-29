using System.Web.Http.Dependencies;
using IDependencyResolver = System.Web.Mvc.IDependencyResolver;
using Autofac;

namespace MealsApi.Utils.Autofac
{
    public class AutofacResolver : AutofacDependencyScope, IDependencyResolver
    {
        private readonly IContainer _container;

        public AutofacResolver(IContainer container)
            : base(container)
        {
            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new AutofacDependencyScope(_container.BeginLifetimeScope());
        }
    }
}