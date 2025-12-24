using APICarros.Applications;
using APICarros.Data.Context;
using APICarros.Domain;
using APICarros.Interface;
using Microsoft.EntityFrameworkCore;


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
            var carro = await _context.Carros.FirstOrDefaultAsync(c => c.Id == data.Id);

            if(carro == null) throw new KeyNotFoundException($"Carro with ID {data.Id} not found.");

            carro.Modelo = data.Modelo;
            carro.Ano = data.Ano;
            carro.Cor = data.Cor;
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

            _context.Carros.Remove(dados);
            await _context.SaveChangesAsync();
            return "Dado excluído com sucesso";
        }
        public async Task<IEnumerable<Carro>> GetAllAsync()
        {
            return await _context.Carros.ToListAsync();
        }
    }

}
