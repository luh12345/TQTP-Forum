using System.Collections.Generic;

namespace Insolation.Forum.Api.Services.Login
{
    public interface ILoginService
    {
        IEnumerable<string> Login(string username, string password);
    }
}