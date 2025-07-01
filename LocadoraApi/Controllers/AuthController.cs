using Microsoft.AspNetCore.Mvc;
using LocadoraApi.Data;
using LocadoraApi.DTOs;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == request.Email);

            if (cliente == null || cliente.Senha != request.Senha)
            {
                return Unauthorized(new { mensagem = "Email ou senha inválidos." });
            }

            return Ok(new
            {
                clienteId = cliente.Id,
                nome = cliente.Nome
                // token = "jwt_gerado_aqui"
            });
        }
    }
}