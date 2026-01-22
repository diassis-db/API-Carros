namespace APICarros.Domain
{
    public class Carro
    {
        public int Id { get; protected set; }
        public string Modelo { get; protected set; } = string.Empty;
        public int Ano { get; protected set; }
        public string Cor { get; protected set; } = string.Empty;
        public Carro(int id, string modelo, int ano, string cor)
        {
            Id = id;
            Atualizar(modelo, ano, cor);
        }

        public Carro(string modelo, int ano, string cor)
        {
            Atualizar(modelo, ano, cor);
        }
        public Carro() { } // Construtor padrão para serialização

        public void Atualizar(string modelo, int ano, string cor)
        {
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
        }
    }
}