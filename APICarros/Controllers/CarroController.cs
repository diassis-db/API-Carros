using APICarros.Applications;
using APICarros.Data.Context;
using APICarros.Domain;
using APICarros.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace APICarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;
        public CarroController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        // POST: Cadastrar novo carro.
        [HttpPost]
        [SwaggerOperation(
            Summary = "Inserir um novo modelo de carro na base de dados.")]
        [ProducesResponseType(typeof(Response<Carro>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response<Carro>>> PostCarro(CarroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Carro carro = dto;
            await _carroRepository.SaveAsync(carro);
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
            var carros =  await _carroRepository.GetAllAsync();
            return Ok(carros);
        }

        // GET: Obter carro pelo Id.        
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obter carro pelo Id.")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var carro = await _carroRepository.GetByIdAsync(id);

            if(carro == null) return NotFound();
            return Ok(carro);
        }

        // PUT: Alterar dados do carro.
        [HttpPut()]
        [SwaggerOperation(
            Summary = "Alteração caso seja necessário para modelo, ano e cor")]
        [ProducesResponseType(typeof(Response<Carro>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCarro(int id, CarroDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var carro = await _carroRepository.GetByIdAsync(id);

            if (carro == null) return NotFound();

            carro.Modelo = dto.Modelo;
            carro.Ano = dto.Ano;
            carro.Cor = dto.Cor;
            await _carroRepository.UpdateAsync(carro);

            var response = new Response<Carro>
            {
                Dados = carro,
                Message = "Dados alterados com sucesso.",
                Success = true
            };
            return Ok(response);
        }

        // DELETE: Excluir carro.
        [HttpDelete]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _carroRepository.DeleteAsync(id);

            if (carro == null) return NotFound();

            var response = new Response<string>
            {
                Dados = carro,
                Message = "Dados excluidos com sucesso.",
                Success = true
            };

            return Ok(response);
        }
    }
}