using APICarros.Domain;

namespace APICarros.Applications
{
    public class CarroDto
    {
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Cor { get; set; } = string.Empty;

        public static implicit operator Carro(CarroDto dto) => new Carro(dto.Modelo, dto.Ano, dto.Cor);
    }
}
