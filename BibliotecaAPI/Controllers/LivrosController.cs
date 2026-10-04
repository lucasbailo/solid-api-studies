using BibliotecaAPI.DTOs;
using BibliotecaAPI.Services.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {

        private readonly ILivroService _service;

        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroResponseDto>>> GetAll()
        {
            var livros = await _service.GetAllAsync();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroResponseDto>> GetById(int id)
        {
            var livro = await _service.GetByIdAsync(id);
            if (livro is null)
                return NotFound();

            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult<LivroResponseDto>> Create(LivroCreateDto dto)
        {
            try
            {
                var criado = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LivroUpdateDto dto)
        {
            try
            {
                var atualizado = await _service.UpdateAsync(id, dto);
                if (!atualizado)
                    return NotFound();

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _service.DeleteAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
