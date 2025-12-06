using APICarros.Applications;
using FluentValidation;
namespace APICarros.Domain.Validation
{
    public class CarroValidation : AbstractValidator<Carro>
    {
        public CarroValidation()
        {
            RuleFor(car => car.Modelo).NotEmpty().WithMessage(CarResource.MODELO);
            RuleFor(car => car.Ano).GreaterThan(1900).WithMessage(CarResource.ANO);
            RuleFor(car => car.Cor).NotEmpty().WithMessage(CarResource.COR);
        }
    }
}
