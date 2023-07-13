using Core.Domain;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class ClienteRepository
{
    private readonly DatabaseContext _context;
    public ClienteRepository(DatabaseContext context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public async Task<Cliente> GetClienteAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

}
