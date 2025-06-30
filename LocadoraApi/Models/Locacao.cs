using System;

namespace LocadoraApi.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        public string PacoteSelecionado { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public string Status { get; set; } // "Em uso", "Devolvido", "Atrasado"
        public double PrecoTotal { get; set; }
    }
}
