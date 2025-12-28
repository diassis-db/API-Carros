using APICarros.Domain;

namespace CarroAPITests.Testes
{
    public class CarroTeste
    {
        [Fact]
        public void DeveRetornarDadosDoCarro()
        {
            // Arrange & Act
            var car = new Carro
            {
                Id = 1,
                Modelo = "Ford Ka",
                Ano = 2020,
                Cor = "Vermelho"
            };

            // Assert
            Assert.Equal(1, car.Id);
            Assert.Equal("Ford Ka", car.Modelo);
            Assert.Equal(2020, car.Ano);
            Assert.Equal("Vermelho", car.Cor);
        }

        [Fact]
        public void DeveCriarCarroComConstrutor()
        {
            // Arrange & Act
            var car = new Carro(2, "Chevrolet Onix", 2021, "Preto");
            // Assert
            Assert.Equal(2, car.Id);
            Assert.Equal("Chevrolet Onix", car.Modelo);
            Assert.Equal(2021, car.Ano);
            Assert.Equal("Preto", car.Cor);
        }

        [Fact]
        public void DevePermitirAlterarPropriedadesDoCarro()
        {
            // Arrange
            var car = new Carro
            {
                Id = 3,
                Modelo = "Volkswagen Gol",
                Ano = 2019,
                Cor = "Branco"
            };
            // Act
            car.Modelo = "Volkswagen Polo";
            car.Ano = 2022;
            car.Cor = "Azul";
            // Assert
            Assert.Equal("Volkswagen Polo", car.Modelo);
            Assert.Equal(2022, car.Ano);
            Assert.Equal("Azul", car.Cor);
        }

        [Fact]
        public void DeveCriarCarroComConstrutorPadrao()
        {
            // Arrange & Act
            var car = new Carro();
            // Assert
            Assert.NotNull(car);
        }

        [Fact]
        public void DevePermitirAnoFuturo()
        {
            // Arrange & Act
            var car = new Carro
            {
                Id = 4,
                Modelo = "Tesla Model 3",
                Ano = 2030,
                Cor = "Prata"
            };
            // Assert
            Assert.Equal(4, car.Id);
            Assert.Equal("Tesla Model 3", car.Modelo);
            Assert.Equal(2030, car.Ano);
            Assert.Equal("Prata", car.Cor);
        }
    }
}
