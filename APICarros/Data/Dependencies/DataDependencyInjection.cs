using APICarros.Interface;
using APICarros.Repositorys;

namespace APICarros.Data.Dependencies
{
    public static class DataDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICarroRepository, CarroRepository>();

            return services;
        }
    }
}
