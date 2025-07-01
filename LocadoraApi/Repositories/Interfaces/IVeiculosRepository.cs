using LocadoraApi.Models;
using System.Collections.Generic;

namespace LocadoraApi.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        List<Veiculo> Listar();
        Veiculo BuscarPorId(int id);
        void Criar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        void Deletar(int id);
    }
}