using APICarros.Domain;

namespace APICarros.Applications
{
    public class CarroDto
    {
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }

        public static implicit operator Carro(CarroDto dto ) => new Carro
        {
            Modelo = dto.Modelo,
            Ano = dto.Ano,
            Cor = dto.Cor
        };
    }
}
