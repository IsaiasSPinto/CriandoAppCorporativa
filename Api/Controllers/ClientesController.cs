using Core.Domain;
using Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteManager _clienteManager;
    public ClientesController(IClienteManager clienteManager)
    {
        _clienteManager = clienteManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _clienteManager.GetClientesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _clienteManager.GetClienteAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(Cliente cliente)
    {
        var clienteInserido = await _clienteManager.InsertClienteAsync(cliente);

        return CreatedAtAction(nameof(Get),new { id = cliente.Id } , cliente);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Cliente cliente)
    {
        var clienteAtualizado = await _clienteManager.UpdateClienteAsync(cliente);

        if (clienteAtualizado == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteManager.DeleteClienteAsync(id);

        return NoContent();
    }
}
