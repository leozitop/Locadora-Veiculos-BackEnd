using LocadoraApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<Cliente> clientes = new();
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var cliente = clientes.FirstOrDefault(c => c.Email == request.Email);
            if (cliente == null) return Unauthorized("Email não cadastrado.");

            // Aqui, você deve validar o hash da senha. Aqui só um exemplo simples.
            if (cliente.SenhaHash != request.Senha)
                return Unauthorized("Senha incorreta.");

            var token = GenerateJwtToken(cliente.Email);

            return Ok(new LoginResponse { Token = token, Nome = cliente.Nome });
        }

        [HttpPost("register")]
        public IActionResult Register(Cliente novoCliente)
        {
            if (clientes.Any(c => c.Email == novoCliente.Email))
                return BadRequest("Email já cadastrado.");

            // Na prática: hash a senha antes de salvar
            clientes.Add(novoCliente);
            return Ok("Cliente cadastrado com sucesso.");
        }

        private string GenerateJwtToken(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}