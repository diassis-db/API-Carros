using APICarros.Data;
using APICarros.Domain;
using APICarros.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace APICarros.Repositorys
{
    public class CarroRepository : ICarroRepository
    {
        private readonly MySqlContext _context;

        public CarroRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Carro data)
        {
            _context.Entry(data).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Carro data)
        {
            _context.Carros.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Carro> GetByIdAsync(int id)
        {
            var dados = await _context.Carros.FindAsync(id);
            if(dados == null)
            {
                throw new KeyNotFoundException($"Carro with ID {id} not found.");
            }
            return dados;
        }

        public async Task<string> DeleteAsync(int id)
        {
            var dados = await _context.Carros.FirstOrDefaultAsync(i => i.Id == id);
            if(dados is null) return "Id não encontrado.";

            _context.Carros.Update(dados);
            await _context.SaveChangesAsync();
            return "Dado excluído com sucesso";
        }
        public async Task<IEnumerable<Carro>> GetAllAsync()
        {
            return await _context.Carros.ToListAsync();
        }

        Task<Carro> ICarroRepository.UpdateAsync(Carro data)
        {
            throw new NotImplementedException();
        }
    }

}
