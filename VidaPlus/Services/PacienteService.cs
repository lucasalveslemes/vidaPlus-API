using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidaPlus.Dtos.Paciente;
using VidaPlus.Domain.Entities;
using VidaPlus.Repositories.Interfaces;
using VidaPlus.Services.Interfaces;

namespace VidaPlus.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repo;
        public PacienteService(IPacienteRepository repo)
        {
            _repo = repo;
        }

        private PacienteReadDto MapToReadDto(Paciente p)
        {
            if (p == null) return null;

            return new PacienteReadDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email,
                CPF = p.CPF,
                Telefone = p.Telefone,
                Endereco = p.Endereco,
                DataNascimento = p.DataNascimento,
                Observacoes = p.Observacoes

            };
        }

        public async Task<PacienteReadDto> CreateAsync(PacienteCreateDto dto)
        {
            dto.Email = dto.Email.Trim().ToLower();
            dto.CPF = dto.CPF.Trim();

            var paciente = new Paciente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                CPF = dto.CPF,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                DataNascimento = dto.DataNascimento,
                Observacoes = dto.Observacoes

            };

            var created = await _repo.AddAsync(paciente);
            return MapToReadDto(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(existing);
            return true;

        }

        public async Task<IEnumerable<PacienteReadDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(MapToReadDto);
        }

        public async Task<PacienteReadDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return MapToReadDto(p);
        }

        public async Task<bool> UpdateAsync(int id, PacienteUpdateDto dto)
        {
            dto.Email = dto.Email.Trim().ToLower();
            dto.CPF = dto.CPF.Trim();

            var existing = await _repo.GetByIdAsync(id);
                if (existing == null) return false;

            existing.Nome = dto.Nome;
            existing.Email = dto.Email;
            existing.CPF = dto.CPF;
            existing.Telefone = dto.Telefone;
            existing.Endereco = dto.Endereco;
            existing.DataNascimento = dto.DataNascimento;
            existing.Observacoes = dto.Observacoes;

            await _repo.UpdateAsync(existing);
            return true;
        }
    }
}
