﻿using Insolation.Forum.Api.Entities.Roles;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Entities.User
{
    public class User
    {
        public User()
        {
            _id = ObjectId.GenerateNewId();
            Roles = new List<Role>() { new Role { Descricao = "Guest" } };
        }

        [BsonId]
        public ObjectId _id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        public IList<Role> Roles { get; set; }
    }
}