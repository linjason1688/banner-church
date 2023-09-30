namespace App.Application.Authenticate.Dtos
{
    /// <summary>
    /// </summary>
    public class SignInResponse
    {
        public string Jwt { get; set; }

        public UserProfile User { get; set; }
    }
}
