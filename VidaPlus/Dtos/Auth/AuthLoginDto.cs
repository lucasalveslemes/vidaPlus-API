using System.ComponentModel.DataAnnotations;

namespace VidaPlus.Dtos.Auth
{
    public class AuthLoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Senha { get; set; }
    }
}
