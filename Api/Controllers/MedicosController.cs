using Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly IClienteManager _medicoManager;
    private readonly ILogger<MedicosController> _logger;

    public MedicosController(IClienteManager medicoManager, ILogger<MedicosController> logger)
    {
        _medicoManager = medicoManager;
        _logger = logger;
    }
}
