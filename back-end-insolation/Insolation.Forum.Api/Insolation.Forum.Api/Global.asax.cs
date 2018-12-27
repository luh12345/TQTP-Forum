using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Integration.WebApi;
using Insolation.Forum.Api.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Insolation.Forum.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            HttpConfiguration config = GlobalConfiguration.Configuration;
            ContainerBuilder builder = ContainerFactory.GetContainer();

            //Register api's controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //Register autofac filter
            builder.RegisterWebApiFilterProvider(config);

            //register autofac model binder
            builder.RegisterWebApiModelBinderProvider();

            //set the dependecy resolver to be autofac
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
