using MF.Domain.Dtos;
using MF.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manufacturing_Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var token = await _authService.SignInAsync(loginUserDto.UserName, loginUserDto.Password);
            if (token == null) return Unauthorized("Usuario o contraseña incorrecta");
            return Ok(new { token });
        }
    }

}
