using Insolation.Forum.Api.Entities.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insolation.Forum.Api.Entities.User
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IList<Role> Roles { get; set; }
    }
}