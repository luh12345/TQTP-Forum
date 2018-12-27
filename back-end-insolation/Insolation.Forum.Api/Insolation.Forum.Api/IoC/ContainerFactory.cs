using Autofac;
using Insolation.Forum.Api.Services.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Insolation.Forum.Api.IoC
{
    public static class ContainerFactory
    {
        public static ContainerBuilder GetContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            return builder;
        }
    }
}