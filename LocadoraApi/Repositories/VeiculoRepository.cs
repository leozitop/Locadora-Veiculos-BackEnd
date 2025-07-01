using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private static List<Veiculo> veiculos = new List<Veiculo>();

        public List<Veiculo> Listar() => veiculos;

        public Veiculo BuscarPorId(int id) =>
            veiculos.FirstOrDefault(v => v.Id == id);

        public void Criar(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count > 0 ? veiculos.Max(v => v.Id) + 1 : 1;
            veiculos.Add(veiculo);
        }

        public void Atualizar(Veiculo atualizado)
        {
            var veiculo = BuscarPorId(atualizado.Id);
            if (veiculo == null) return;

            veiculo.Marca = atualizado.Marca;
            veiculo.Modelo = atualizado.Modelo;
            veiculo.AnoFabricacao = atualizado.AnoFabricacao;
            veiculo.Preco = atualizado.Preco;
        }

        public void Deletar(int id)
        {
          var veiculo = BuscarPorId(id);
            if (veiculo != null)
                veiculos.Remove(veiculo);
        }
    }
}