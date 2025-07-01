using LocadoraApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AlugueisController : ControllerBase
    {
        private static List<Aluguel> alugueis = new();

        [HttpGet]
        public IActionResult GetAlugueis()
        {
            return Ok(alugueis);
        }

        [HttpPost]
        public IActionResult CriarAluguel(Aluguel aluguel)
        {
            aluguel.Id = alugueis.Count + 1;
            alugueis.Add(aluguel);
            return Ok(aluguel);
        }
    }
}
