using Microsoft.EntityFrameworkCore;
using VidaPlus.Data;
using VidaPlus.Domain.Entities;
using VidaPlus.Repositories.Interfaces;

namespace VidaPlus.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly AppDbContext _context;

        public ConsultaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> GetAllAsync()
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Profissional)
                .ToListAsync();
        }

        public async Task<Consulta?> GetByIdAsync(int id)
        {
            return await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Profissional)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
