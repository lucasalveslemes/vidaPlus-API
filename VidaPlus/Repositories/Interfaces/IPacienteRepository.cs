using System.Collections.Generic;
using System.Threading.Tasks;
using VidaPlus.Domain.Entities;

namespace VidaPlus.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task<Paciente> AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(Paciente paciente);
        Task<bool> ExistsAsync(int id);
    }
}
