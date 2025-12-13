using APICarros.Applications;
using APICarros.Data;
using APICarros.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

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

        // POST: Cadastrar novo carro.
        [HttpPost]
        [SwaggerOperation(
            Summary = "Inserir um novo modelo de carro na base de dados.")]
        [ProducesResponseType(typeof(Response<Carro>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response<Carro>>> PostCarro(CarroDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Carro carro = dto;
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();
            var response = new Response<Carro>
            {
                Dados = carro,
                Message = "Carro criado com sucesso.",
                Success = true
            };

            return CreatedAtAction("GetCarro", new { id = carro.Id }, response);
        }

        // GET: Listar todos os carros.
        [HttpGet]
        [SwaggerOperation(
            Summary = "Obter todos os carros cadastrados na base de dados.")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
            return await _context.Carros.ToListAsync();
        }

        // GET: Obter carro pelo Id.        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter carro pelo Id.")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: Alterar dados do carro.
        [HttpPut()]
        [SwaggerOperation(
            Summary = "Alteração caso seja necessário para modelo, ano e cor")]
        [ProducesResponseType(typeof(Response<Carro>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCarro(int id, CarroDto dto)
        {
            var carro = await _context.Carros.FindAsync(id);

            if(carro == null)
            {
                return NotFound();
            }

            try
            {
                Carro carro1 = dto;
                await _context.SaveChangesAsync();

                var response = new Response<Carro>
                {
                    Dados = carro,
                    Message = "Alterações realizada com sucesso.",
                    Success = true
                };

                return Ok(response);
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
        }

        // DELETE: Excluir carro.
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
            var response = new Response<Carro>
            {
                Dados = carro,
                Message = "Dados excluidos com sucesso.",
                Success = true
            };

            return Ok(response);
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}
