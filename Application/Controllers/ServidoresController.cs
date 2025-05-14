using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServidorPublico.Application.Servidores.Commands.Create;
using ServidorPublico.Application.Servidores.Commands.Inativar;
using ServidorPublico.Application.Servidores.Commands.Update;
using ServidorPublico.Application.Servidores.Queries;

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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetServidoresQuery query)
    {
        var servidores = await _mediator.Send(query);
        return Ok(servidores);
    }

    [HttpGet("{id}")]
    public IActionResult ObterServidorPorId(Guid id)
    {
        return Ok(); // Implementaremos depois
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateServidorCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID da URL não corresponde ao do corpo da requisição.");

        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new InativarServidorCommand(id));
        return NoContent();
    }

    
}
