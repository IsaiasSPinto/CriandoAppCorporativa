using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class MedicoRepository : IMedicoRepository
{
    private readonly DatabaseContext _context;
    public MedicoRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medico>> GetMedicosAsync()
    {
        return await _context.Medicos
            .Include(x => x.Especialidades)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Medico> GetMedicoAsync(int id)
    {
        return await _context.Medicos
            .Include(x => x.Especialidades)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Medico> InsertMedicoAsync(Medico medico)
    {
        await _context.Medicos.AddAsync(medico);
        await _context.SaveChangesAsync();

        return medico;
    }
    public async Task<Medico> UpdateMedicoAsync(Medico medico)
    {
        var medicoConsultado = await _context.Clientes.FindAsync(medico.Id);

        if (medicoConsultado == null)
        {
            return null;
        }

        _context.Entry(medicoConsultado).CurrentValues.SetValues(medico);

        await _context.SaveChangesAsync();

        return medico;
    }

    public async Task DeleteMedicoAsync(int id)
    {
        var medicoConsultado = await _context.Clientes.FindAsync(id);

        if (medicoConsultado == null) return;

        _context.Clientes.Remove(medicoConsultado);
        await _context.SaveChangesAsync();
    }

}
