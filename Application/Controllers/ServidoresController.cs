using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServidorPublico.Application.Servidores.Commands.Create;

namespace ServidorPublico.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServidoresController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServidoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarServidor([FromBody] CreateServidorCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterServidorPorId), new { id }, null);
    }

    [HttpGet("{id}")]
    public IActionResult ObterServidorPorId(Guid id)
    {
        return Ok(); // Implementaremos depois
    }
}
