﻿using Core.Domain;
using Data.Context;
using Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class ClienteRepository : IClienteRepository
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

    public async Task<Cliente> InsertClienteAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
    {
        var clienteConsultado = await _context.Clientes.FindAsync(cliente.Id);

        if(clienteConsultado == null)
        {
            return null;
        }

        _context.Entry(clienteConsultado).CurrentValues.SetValues(cliente);

        await _context.SaveChangesAsync();

        return cliente;
    }

    public async Task DeleteClienteAsync(int id)
    {
        var clienteConsultado = await _context.Clientes.FindAsync(id);

        _context.Clientes.Remove(clienteConsultado);
        await _context.SaveChangesAsync();
    }
}
