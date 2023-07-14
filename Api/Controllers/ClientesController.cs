using Core.Domain;
using Core.ModelViews;
using Manager.Interfaces;
using Manager.Validator;
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
    public async Task<IActionResult> Post(NovoCliente novoCliente)
    {          
        var clienteInserido = await _clienteManager.InsertClienteAsync(novoCliente);

        return CreatedAtAction(nameof(Get),new { id = clienteInserido.Id } , clienteInserido);
    }

    [HttpPut]
    public async Task<IActionResult> Put(AlteraCliente clienteAlterado)
    {
        var clienteAtualizado = await _clienteManager.UpdateClienteAsync(clienteAlterado);

        if (clienteAtualizado == null)
        {
            return NotFound();
        }

        return Ok(clienteAtualizado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteManager.DeleteClienteAsync(id);

        return NoContent();
    }
}
