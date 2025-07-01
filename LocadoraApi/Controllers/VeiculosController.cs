using Microsoft.AspNetCore.Mvc;
using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _repo;

        public VeiculosController(IVeiculoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_repo.Listar());

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var veiculo = _repo.BuscarPorId(id);
            if (veiculo == null) return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Veiculo veiculo)
        {
            _repo.Criar(veiculo);
            return CreatedAtAction(nameof(BuscarPorId), new { id = veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Veiculo atualizado)
        {
            var veiculoExistente = _repo.BuscarPorId(id);
            if (veiculoExistente == null) return NotFound();

            atualizado.Id = id;
            _repo.Atualizar(atualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var veiculo = _repo.BuscarPorId(id);
            if (veiculo == null) return NotFound();

            _repo.Deletar(id);
            return NoContent();
        }
    }
}