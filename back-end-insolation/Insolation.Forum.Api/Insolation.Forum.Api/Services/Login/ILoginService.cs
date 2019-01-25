using Insolation.Forum.Api.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insolation.Forum.Api.Services.Login
{
    public interface ILoginService
    {
        Task<IEnumerable<string>> Login(string username, string password);
        Task<User> SignUp(User user);
    }
}