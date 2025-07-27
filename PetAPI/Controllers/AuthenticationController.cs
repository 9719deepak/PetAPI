using Microsoft.AspNetCore.Mvc;
using PetAPI.Services;

namespace PetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthenticationController(JwtTokenService tokenService) => _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user.Username == "admin" && user.Password == "admin123")
            {
                var token = _tokenService.GenerateToken(user.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }

    }
}
