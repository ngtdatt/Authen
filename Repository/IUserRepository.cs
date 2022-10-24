using AuthenWeb.Models;

namespace AuthenWeb.Repository
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        User? LoginUser(string email, string password);

        void Add(User user);
    }
}
