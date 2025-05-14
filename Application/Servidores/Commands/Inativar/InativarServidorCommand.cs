using MediatR;

namespace ServidorPublico.Application.Servidores.Commands.Inativar;

public class InativarServidorCommand : IRequest
{
    public Guid Id { get; set; }

    public InativarServidorCommand(Guid id)
    {
        Id = id;
    }
}
