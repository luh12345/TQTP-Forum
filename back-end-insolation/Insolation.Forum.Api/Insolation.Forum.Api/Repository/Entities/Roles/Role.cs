using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Entities.Roles
{
    public class Role
    {
        public string Descricao { get; set; }
    }
}