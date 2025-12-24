using APICarros.Domain;

namespace APICarros.Interface
{
    public interface ICarroRepository
    {
            Task SaveAsync(Carro data);
            Task<IEnumerable<Carro>> GetAllAsync();
            Task UpdateAsync(Carro data);
            Task<Carro> GetByIdAsync(int id);
            Task<string> DeleteAsync(int id);
    }
}
