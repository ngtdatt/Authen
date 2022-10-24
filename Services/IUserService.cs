using AuthenWeb.Models;

namespace AuthenWeb.Services
{
    public interface IUserService
    {
        Task<UserDto> SignUp(CreateUserDto createUser);
        Task<UserDto> Login(string email, string password);
        Task<IResult> Logout(string username);
        Task<IResult> Refresh(string username);

    }
}
