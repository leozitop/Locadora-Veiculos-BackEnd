using LocadoraApi.Models;
using System.Collections.Generic;

namespace LocadoraApi.Repositories.Interfaces
{
    public interface IAluguelRepository
    {
        List<Aluguel> Listar();
        Aluguel BuscarPorId(int id);
        void Criar(Aluguel aluguel);
        void Atualizar(Aluguel aluguel);
        void Deletar(int id);
    }
}