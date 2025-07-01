using Microsoft.AspNetCore.Mvc;
using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClientesController(IClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.Listar());

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var cliente = _repo.BuscarPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Cliente cliente)
        {
            _repo.Criar(cliente);
            return CreatedAtAction(nameof(BuscarPorId), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente atualizado)
        {
            var clienteExistente = _repo.BuscarPorId(id);
            if (clienteExistente == null) return NotFound();

            atualizado.Id = id;
            _repo.Atualizar(atualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var cliente = _repo.BuscarPorId(id);
            if (cliente == null) return NotFound();

            _repo.Deletar(id);
            return NoContent();
        }
    }
}