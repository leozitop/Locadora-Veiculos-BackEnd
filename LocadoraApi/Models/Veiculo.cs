namespace LocadoraApi.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
        public double Litragem { get; set; }
        public double QuilometragemTotal { get; set; }
        public string FotoUrl { get; set; }
    }
}
