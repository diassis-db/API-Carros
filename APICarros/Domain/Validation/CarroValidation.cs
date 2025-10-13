using FluentValidation;
namespace APICarros.Domain.Validation
{
    public class CarroValidation : AbstractValidator<Carro>
    {
        public CarroValidation()
        {
            RuleFor(car => car.Modelo).NotEmpty().WithMessage("O modelo do carro é obrigatório.");
            RuleFor(car => car.Ano).GreaterThan(1900).WithMessage("Ano de Fabricação deve ser maior que 1900.");
            RuleFor(car => car.Cor).NotEmpty().WithMessage("A cor do carro é obrigatória.");
        }
    }
}
