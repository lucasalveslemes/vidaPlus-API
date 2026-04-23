using System.Collections.Generic;
using System.Threading.Tasks;
using VidaPlus.Dtos.Paciente;

namespace VidaPlus.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteReadDto>> GetAllAsync();
        Task<PacienteReadDto> GetByIdAsync(int id);
        Task<PacienteReadDto> CreateAsync(PacienteCreateDto dto);
        Task<bool> UpdateAsync(int id, PacienteUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

