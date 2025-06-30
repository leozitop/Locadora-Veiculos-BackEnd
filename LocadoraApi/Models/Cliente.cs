using System.Collections.Generic;

namespace LocadoraApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string CNHStatus { get; set; } // "Ativa" ou "Inativa"

        public List<Locacao> Locacoes { get; set; }
    }
}
