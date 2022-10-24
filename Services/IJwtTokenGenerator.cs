using AuthenWeb.Models;

namespace AuthenWeb.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);

    }
}
