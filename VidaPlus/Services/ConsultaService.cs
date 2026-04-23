using VidaPlus.Domain.Entities;
using VidaPlus.Dtos.Consulta;
using VidaPlus.Repositories.Interfaces;
using VidaPlus.Services.Interfaces;

namespace VidaPlus.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public async Task<IEnumerable<ConsultaReadDto>> GetAllAsync()
        {
            var consultas = await _consultaRepository.GetAllAsync();

            return consultas.Select(c => new ConsultaReadDto
            {
                Id = c.Id,
                DataHora = c.DataHora,
                PacienteNome = c.Paciente.Nome,
                ProfissionalNome = c.Profissional.Nome,
                Observacoes = c.Observacoes
            });
        }

        public async Task<ConsultaReadDto?> GetByIdAsync(int id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            if (consulta == null) return null;

            return new ConsultaReadDto
            {
                Id = consulta.Id,
                DataHora = consulta.DataHora,
                PacienteNome = consulta.Paciente.Nome,
                ProfissionalNome = consulta.Profissional.Nome,
                Observacoes = consulta.Observacoes
            };
        }

        public async Task<ConsultaReadDto> CreateAsync(ConsultaCreateDto dto)
        {
            var consulta = new Consulta
            {
                DataHora = dto.DataHora,
                PacienteId = dto.PacienteId,
                ProfissionalId = dto.ProfissionalId,
                Observacoes = dto.Observacoes
            };

            await _consultaRepository.AddAsync(consulta);

            return new ConsultaReadDto
            {
                Id = consulta.Id,
                DataHora = consulta.DataHora,
                PacienteNome = consulta.Paciente?.Nome ?? "",
                ProfissionalNome = consulta.Profissional?.Nome ?? "",
                Observacoes = consulta.Observacoes
            };
        }

        public async Task UpdateAsync(int id, ConsultaCreateDto dto)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            if (consulta == null) throw new Exception("Consulta não encontrada.");

            consulta.DataHora = dto.DataHora;
            consulta.PacienteId = dto.PacienteId;
            consulta.ProfissionalId = dto.ProfissionalId;
            consulta.Observacoes = dto.Observacoes;

            await _consultaRepository.UpdateAsync(consulta);
        }

        public async Task DeleteAsync(int id)
        {
            await _consultaRepository.DeleteAsync(id);
        }
    }
}
