using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICarros.Data;
using APICarros.Domain;

namespace APICarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly MySqlContext _context;

        public CarroController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Carro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
            return await _context.Carros.ToListAsync();
        }

        // GET: api/Carro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carro
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
        }

        // DELETE: api/Carro/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
