using Insolation.Forum.Api.Common.Exceptions.Security;
using Insolation.Forum.Api.Common.Helper;
using Insolation.Forum.Api.Entities.User;
using Insolation.Forum.Api.Repository.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Insolation.Forum.Api.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IInsolationContext context;

        public LoginService(IInsolationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<string>> Login(string username, string password)
        {
            IMongoCollection<User> usersCollection = context.Database.GetCollection<User>("Users");
            FindOptions<User, User> findOptions = new FindOptions<User, User>();
            findOptions.Limit = 1;
            findOptions.MaxAwaitTime = TimeSpan.FromSeconds(20);
            IAsyncCursor<User> cursorUsers = await usersCollection.FindAsync(x => x.Username == username && x.Password == password);

            using (cursorUsers)
            {
                List<User> usersResult = await cursorUsers.ToListAsync();
                if (!usersResult.Any())
                    throw new SecurityException("Usuário ou senha inválidos.");

                User user = usersResult.FirstOrDefault();
                return user.Roles.Select(x => x.Descricao);
            }
        }

        public async Task<User> SignUp(User user)
        {
            IMongoCollection<User> usersCollection = context.Database.GetCollection<User>("Users");
            IAsyncCursor<User> foundUsers = await usersCollection.FindAsync(x => x.Username == user.Username || x.Email == user.Email);

            IEnumerable<User> users = await foundUsers.ToListAsync();
            if (users.Any())
                throw new Exception("Username ou e-mail já cadastrados.");

            user.Password = Cypher.Encrypt(user.Password);
            await usersCollection.InsertOneAsync(user);
            return user;
        }
    }
}