using VidaPlus.Dtos.Profissional;

namespace VidaPlus.Services.Interfaces
{
    public interface IProfissionalService
    {
        Task<ProfissionalReadDto> CreateAsync(ProfissionalCreateDto dto);
        Task<List<ProfissionalReadDto>> GetAllAsync();
        Task<ProfissionalReadDto?> GetByIdAsync(int id);
        Task<ProfissionalReadDto?> UpdateAsync(int id, ProfissionalUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
