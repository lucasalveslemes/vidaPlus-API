using VidaPlus.Dtos.Consulta;

namespace VidaPlus.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaReadDto>> GetAllAsync();
        Task<ConsultaReadDto?> GetByIdAsync(int id);
        Task<ConsultaReadDto> CreateAsync(ConsultaCreateDto dto);
        Task UpdateAsync(int id, ConsultaCreateDto dto);
        Task DeleteAsync(int id);
    }
}
