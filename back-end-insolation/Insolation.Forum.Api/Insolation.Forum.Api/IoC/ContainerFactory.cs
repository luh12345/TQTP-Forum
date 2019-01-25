using Autofac;
using Insolation.Forum.Api.Services.Jwt;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            builder.Register<IMongoClient>((c, p) =>
            {
                return new MongoClient(ConfigurationManager.AppSettings["mongo.connection"]);
            });
            return builder;
        }
    }
}