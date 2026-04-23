using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VidaPlus.Services;
using VidaPlus.Dtos.Auth;

namespace VidaPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (!result)
                return BadRequest("Usuário já cadastrado com este email.");
            return Ok("Usuário cadastrado com sucesso!");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return Unauthorized("Credenciais inválidas!");
            return Ok(new { Token = token });
        }
    }
}
