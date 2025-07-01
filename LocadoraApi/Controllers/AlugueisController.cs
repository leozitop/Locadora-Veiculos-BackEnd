using Microsoft.AspNetCore.Mvc;
using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlugueisController : ControllerBase
    {
        private readonly IAluguelRepository _repo;

        public AlugueisController(IAluguelRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.Listar());

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var aluguel = _repo.BuscarPorId(id);
            if (aluguel == null) return NotFound();
            return Ok(aluguel);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Aluguel aluguel)
        {
            _repo.Criar(aluguel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = aluguel.Id }, aluguel);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Aluguel atualizado)
        {
            var aluguelExistente = _repo.BuscarPorId(id);
            if (aluguelExistente == null) return NotFound();

            atualizado.Id = id;
            _repo.Atualizar(atualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var aluguel = _repo.BuscarPorId(id);
            if (aluguel == null) return NotFound();

            _repo.Deletar(id);
            return NoContent();
        }
    }
}