using LocadoraApi.Models;
using System.Collections.Generic;

namespace LocadoraApi.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> Listar();
        Cliente BuscarPorId(int id);
        void Criar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Deletar(int id);
    }
}