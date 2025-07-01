using System.Collections.Generic;

namespace LocadoraApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Idade { get; set; } = null!;
        public string CNHStatus { get; set; } = null!;// "Ativa" ou "Inativa"
        public string SenhaHash { get; set; } = null!;

        public List<Aluguel> Alugueis { get; set; }
    }
}
