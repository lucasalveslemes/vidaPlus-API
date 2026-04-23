using VidaPlus.Domain.Entities;
using VidaPlus.Dtos.Profissional;
using VidaPlus.Repositories.Interfaces;
using VidaPlus.Services.Interfaces;

namespace VidaPlus.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _repository;

        public ProfissionalService(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProfissionalReadDto> CreateAsync(ProfissionalCreateDto dto)
        {
            var profissional = new Profissional
            {
                Nome = dto.Nome,
                Especialidade = dto.Especialidade,
                RegistroProfissional = dto.RegistroProfissional,
                Telefone = dto.Telefone
            };

            await _repository.AddAsync(profissional);

            return MapToReadDto(profissional);
        }

        public async Task<List<ProfissionalReadDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(MapToReadDto).ToList();
        }

        public async Task<ProfissionalReadDto?> GetByIdAsync(int id)
        {
            var profissional = await _repository.GetByIdAsync(id);
            if (profissional == null)
                return null;

            return MapToReadDto(profissional);
        }

        public async Task<ProfissionalReadDto?> UpdateAsync(int id, ProfissionalUpdateDto dto)
        {
            var profissional = await _repository.GetByIdAsync(id);
            if (profissional == null)
                return null;

            profissional.Nome = dto.Nome;
            profissional.Especialidade = dto.Especialidade;
            profissional.RegistroProfissional = dto.RegistroProfissional;
            profissional.Telefone = dto.Telefone;

            await _repository.UpdateAsync(profissional);

            return MapToReadDto(profissional);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profissional = await _repository.GetByIdAsync(id);
            if (profissional == null)
                return false;

            await _repository.DeleteAsync(profissional);
            return true;
        }

        private ProfissionalReadDto MapToReadDto(Profissional profissional)
        {
            return new ProfissionalReadDto
            {
                Id = profissional.Id,
                Nome = profissional.Nome,
                Especialidade = profissional.Especialidade,
                RegistroProfissional = profissional.RegistroProfissional,
                Telefone = profissional.Telefone
            };
        }
    }
}
