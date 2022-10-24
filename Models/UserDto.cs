namespace AuthenWeb.Models
{
    public class UserDto
    {
        public Guid Id { get; set; } 

        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? DisplayName { get; set; } = null!;
        public string? Token { get; set; } = null!;
        public string? FefreshToken { get; set; } = null!;


        public UserDto(User user, string refreshToken = null)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            DisplayName = user.FirstName + user.LastName;
            Token = user.Token;
            FefreshToken = refreshToken;

        }

    }
}
