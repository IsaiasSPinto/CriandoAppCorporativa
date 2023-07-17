using Core.Domain;
using Core.ModelViews;
using Manager.Interfaces.Manager;
using Manager.Validator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteManager _clienteManager;
    private readonly ILogger<ClientesController> _logger;

    public ClientesController(IClienteManager clienteManager, ILogger<ClientesController> logger)
    {
        _clienteManager = clienteManager;
        _logger = logger;
    }

    /// <summary>
    ///  Retorna todos os clientes cadastrados
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Cliente),StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _clienteManager.GetClientesAsync());
    }

    /// <summary>
    /// Retorna um cliente consultado pelo id.
    /// </summary>
    /// <param name="id" example="1">Id do cliente.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _clienteManager.GetClienteAsync(id));
    }


    /// <summary>
    /// Insere um novo cliente
    /// </summary>
    /// <param name="novoCliente"></param>
    [HttpPost]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(NovoCliente novoCliente)
    {
        _logger.LogInformation("Foi requisitado a inserção de um novo cliente");
        var clienteInserido = await _clienteManager.InsertClienteAsync(novoCliente);

        return CreatedAtAction(nameof(Get),new { id = clienteInserido.Id } , clienteInserido);
    }

    /// <summary>
    /// Altera um cliente existente.
    /// </summary>
    /// <param name="clienteAlterado"></param>
    [HttpPut]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(AlteraCliente clienteAlterado)
    {
        var clienteAtualizado = await _clienteManager.UpdateClienteAsync(clienteAlterado);

        if (clienteAtualizado == null)
        {
            return NotFound();
        }

        return Ok(clienteAtualizado);
    }

    /// <summary>
    /// Remove um cliente.
    /// </summary>
    /// <param name="id" example="1">Id do cliente</param>
    /// <remarks>Ao remover um cliente o mesmo será removido permanentemente da base de dados.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteManager.DeleteClienteAsync(id);

        return NoContent();
    }
}
