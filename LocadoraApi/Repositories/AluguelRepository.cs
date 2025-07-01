using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private static List<Aluguel> alugueis = new List<Aluguel>();

        public List<Aluguel> Listar() => alugueis;

        public Aluguel BuscarPorId(int id) =>
            alugueis.FirstOrDefault(a => a.Id == id);

        public void Criar(Aluguel aluguel)
        {
            aluguel.Id = alugueis.Count > 0 ? alugueis.Max(a => a.Id) + 1 : 1;
            alugueis.Add(aluguel);
        }

        public void Atualizar(Aluguel atualizado)
        {
            var aluguel = BuscarPorId(atualizado.Id);
            if (aluguel == null) return;

            aluguel.ClienteId = atualizado.ClienteId;
            aluguel.VeiculoId = atualizado.VeiculoId;
            aluguel.DataInicio = atualizado.DataInicio;
            aluguel.DataFim = atualizado.DataFim;
        }

        public void Deletar(int id)
        {
            var aluguel = BuscarPorId(id);
            if (aluguel != null)
                alugueis.Remove(aluguel);
        }
    }
}