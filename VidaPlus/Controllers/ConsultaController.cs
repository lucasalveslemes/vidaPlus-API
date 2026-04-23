using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VidaPlus.Dtos.Consulta;
using VidaPlus.Services.Interfaces;

namespace VidaPlus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Requer login JWT
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultaReadDto>>> GetAll()
        {
            var consultas = await _consultaService.GetAllAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaReadDto>> GetById(int id)
        {
            var consulta = await _consultaService.GetByIdAsync(id);
            if (consulta == null)
                return NotFound(new { message = "Consulta não encontrada." });

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultaReadDto>> Create(ConsultaCreateDto dto)
        {
            var novaConsulta = await _consultaService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = novaConsulta.Id }, novaConsulta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ConsultaCreateDto dto)
        {
            await _consultaService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _consultaService.DeleteAsync(id);
            return NoContent();
        }
    }
}

