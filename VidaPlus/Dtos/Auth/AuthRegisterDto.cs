using System.ComponentModel.DataAnnotations;

namespace VidaPlus.Dtos.Auth
{
    public class AuthRegisterDto
    {
        [Required, StringLength(100)]
        public string Nome { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Senha { get; set; }
    }
}
