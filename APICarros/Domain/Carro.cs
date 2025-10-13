namespace APICarros.Domain
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Cor { get; set; } = string.Empty;
        public Carro(int id, string modelo, int ano, string cor)
        {
            Id = id;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
        }
        public Carro() { } // Construtor padrão para serialização
    }
}
