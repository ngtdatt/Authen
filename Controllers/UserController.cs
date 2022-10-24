using AuthenWeb.Models;
using AuthenWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenWeb.Controllers
{
    public static class UserController
    {
        public static void MapUserAPI(this WebApplication app)
        {
            app.MapPost("/api/user/signup",
                async ([FromBody] CreateUserDto createUser, IUserService userService) =>
                {
                    var result = await userService.SignUp(createUser);
                    return result;
                });

            app.MapPost("/api/user/login",
                async (LoginUser loginUser, IUserService userService) =>
                {
                    var result = await userService.Login(loginUser.Email, loginUser.Password);
                    return result;
                });

        }
    }
}
