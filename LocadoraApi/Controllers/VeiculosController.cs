using LocadoraApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private static List<Veiculo> veiculos = new()
        {
            new Veiculo { Id = 1, Marca = "Toyota", Modelo = "Corolla", PrecoDiaria = 150 },
            new Veiculo { Id = 2, Marca = "Honda", Modelo = "Civic", PrecoDiaria = 160 }
        };

        [HttpGet]
        public IActionResult GetVeiculos()
        {
            return Ok(veiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetVeiculo(int id)
        {
            var veiculo = veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null) return NotFound();
            return Ok(veiculo);
        }
    }
}