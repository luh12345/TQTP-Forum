using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insolation.Forum.Api.Repository.Context
{
    public interface IInsolationContext
    {
        IMongoDatabase Database { get; }
    }
}
