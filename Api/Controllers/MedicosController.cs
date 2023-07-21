using Core.Domain;
using Core.ModelViews.Cliente;
using Core.ModelViews.Medico;
using Data.Repository;
using Manager.Implementation;
using Manager.Interfaces.Manager;
using Manager.Validator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly IMedicoManager _medicoManager;
    private readonly ILogger<MedicosController> _logger;

    public MedicosController(IMedicoManager medicoManager, ILogger<MedicosController> logger)
    {
        _medicoManager = medicoManager;
        _logger = logger;
    }

    /// <summary>
    ///  Retorna todos os medicos cadastrados
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _medicoManager.GetMedicosAsync());
    }

    /// <summary>
    /// Retorna um medico consultado pelo id.
    /// </summary>
    /// <param name="id" example="1">Id do medico.</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _medicoManager.GetMedicoAsync(id));
    }


    /// <summary>
    /// Insere um novo medico
    /// </summary>
    /// <param name="novoMedico"></param>
    [HttpPost]
    [ProducesResponseType(typeof(MedicoView), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(NovoMedico novoMedico)
    {

				var medicoInserido = await _medicoManager.InsertMedicoAsync(novoMedico);

        return CreatedAtAction(nameof(Get), new { id = medicoInserido.Id }, medicoInserido);
    }

    /// <summary>
    /// Altera um medico existente.
    /// </summary>
    /// <param name="medicoAlterado"></param>
    [HttpPut]
    [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(AlteraMedico medicoAlterado)
    {
        var medicoAtualizado = await _medicoManager.UpdateMedicoAsync(medicoAlterado);

        if (medicoAtualizado == null)
        {
            return NotFound();
        }

        return Ok(medicoAtualizado);
    }

    /// <summary>
    /// Remove um medico.
    /// </summary>
    /// <param name="id" example="1">Id do medico</param>
    /// <remarks>Ao remover um medico o mesmo será removido permanentemente da base de dados.</remarks>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(MedicoView), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        await _medicoManager.DeleteMedicoAsync(id);

        return NoContent();
    }
}
