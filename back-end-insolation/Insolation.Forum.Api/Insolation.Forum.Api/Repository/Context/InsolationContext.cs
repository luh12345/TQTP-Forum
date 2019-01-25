using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Repository.Context
{
    public class InsolationContext : IInsolationContext
    {
        public IMongoDatabase Database { get; }

        public InsolationContext(IMongoClient client)
        {
            Database = client.GetDatabase(ConfigurationManager.AppSettings["insolation.db"]);
        }
    }
}