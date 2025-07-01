using LocadoraApi.Models;
using LocadoraApi.Repositories.Interfaces;

namespace LocadoraApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public List<Cliente> Listar() => clientes;

        public Cliente BuscarPorId(int id) =>
            clientes.FirstOrDefault(c => c.Id == id);

        public void Criar(Cliente cliente)
        {
            cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
            clientes.Add(cliente);
        }

        public void Atualizar(Cliente atualizado)
        {
            var cliente = BuscarPorId(atualizado.Id);
            if (cliente == null) return;

            cliente.Nome = atualizado.Nome;
            cliente.Email = atualizado.Email;
            cliente.Telefone = atualizado.Telefone;
        }

        public void Deletar(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente != null)
                clientes.Remove(cliente);
        }
    }
}