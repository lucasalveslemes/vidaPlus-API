using VidaPlus.Domain.Entities;

namespace VidaPlus.Repositories.Interfaces
{
    public interface IConsultaRepository
    {
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task<Consulta?> GetByIdAsync(int id);
        Task AddAsync(Consulta consulta);
        Task UpdateAsync(Consulta consulta);
        Task DeleteAsync(int id);
    }
}
