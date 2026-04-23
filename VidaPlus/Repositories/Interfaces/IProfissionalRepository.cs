using VidaPlus.Domain.Entities;

namespace VidaPlus.Repositories.Interfaces
{
    public interface IProfissionalRepository
    {
        Task<Profissional> AddAsync(Profissional profissional);
        Task<Profissional?> GetByIdAsync(int id);
        Task<List<Profissional>> GetAllAsync();
        Task UpdateAsync(Profissional profissional);
        Task DeleteAsync(Profissional profissional);
    }
}
