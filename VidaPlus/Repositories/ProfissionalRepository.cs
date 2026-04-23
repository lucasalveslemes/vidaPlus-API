using Microsoft.EntityFrameworkCore;
using VidaPlus.Data;
using VidaPlus.Domain.Entities;
using VidaPlus.Repositories.Interfaces;

namespace VidaPlus.Repositories
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly AppDbContext _context;

        public ProfissionalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Profissional> AddAsync(Profissional profissional)
        {
            _context.Profissionais.Add(profissional);
            await _context.SaveChangesAsync();
            return profissional;
        }

        public async Task<List<Profissional>> GetAllAsync()
        {
            return await _context.Profissionais.ToListAsync();
        }

        public async Task<Profissional?> GetByIdAsync(int id)
        {
            return await _context.Profissionais.FindAsync(id);
        }

        public async Task UpdateAsync(Profissional profissional)
        {
            _context.Profissionais.Update(profissional);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Profissional profissional)
        {
            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();
        }
    }
}
