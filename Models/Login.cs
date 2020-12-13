using System.ComponentModel.DataAnnotations;

namespace ASPNETCore5Demo.Models
{
    public class Login
    {
        public class LoginModel
        {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        }

        public class LoginResult
        {
            public string Token { get; set; }
        }
    }
}