using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MicroServiceRepos;

namespace WebApplication1
{
    public static class SimpleInjectorInitializer
    {
        public static void SimpleInjectorInitalizer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
               new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            //Gift
            container.Register<IGiftBoxRepo, MockGiftRepo>(Lifestyle.Singleton);

            //Order
            container.Register<IOrderRepo, MockOrderRepo>(Lifestyle.Singleton);
            
            //Cart
            container.Register<ICartRepo, MockCartRepo>(Lifestyle.Singleton);
            //container.Register<ICartRepo, ConcCartRepo>(Lifestyle.Scoped);
        }
    }
}