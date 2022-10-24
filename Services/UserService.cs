using AuthenWeb.Models;
using AuthenWeb.Repository;
using System.Text.RegularExpressions;


namespace AuthenWeb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;         
        private static readonly Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<UserDto> Login(string email, string password)
        {
            Match match = regex.Match(email);

            if (!match.Success)
                throw new ArgumentException("Invalid Data");

            if (password.Length < 8 && password.Length > 20)
                throw new ArgumentException("Invalid Data");

            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given name does not exist");
            }

            //Validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // Create token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new UserDto(user, token);
        }

        public Task<IResult> Logout(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Refresh(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> SignUp(CreateUserDto createUser)
        {

            ValidateUserData(createUser);

            //Create user
            var user = new User
            {
                FirstName = createUser.FirstName,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Password = createUser.Password
            };

            //Create Token
            var token = _jwtTokenGenerator.GenerateToken(user); 

            user.Token = token;

            _userRepository.Add(user);



            return new UserDto(user);
        }

        private void ValidateUserData(CreateUserDto createUser)
        {
            bool isValid = true;

            if (_userRepository.GetUserByEmail(createUser.Email) is not null)
                isValid = false;

            Match match = regex.Match(createUser.Email);
            if (!match.Success)
                isValid = false;

            if (createUser.Password.Length < 8 && createUser.Password.Length >20)
                isValid = false;

            if (!isValid)
                throw new ArgumentException("Invalid Data");

        }
    }
}
