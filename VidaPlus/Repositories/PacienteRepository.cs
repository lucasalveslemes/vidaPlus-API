using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VidaPlus.Data;
using VidaPlus.Domain.Entities;
using VidaPlus.Repositories.Interfaces;

namespace VidaPlus.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;
        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente> AddAsync(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task DeleteAsync(Paciente paciente)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pacientes.AnyAsync(p => p.Id == id);
        }
    }
}

