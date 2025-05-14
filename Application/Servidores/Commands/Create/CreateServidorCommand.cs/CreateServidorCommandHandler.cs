using MediatR;
using ServidorPublico.Domain.Entities;
using ServidorPublico.Infrastructure.Data;

namespace ServidorPublico.Application.Servidores.Commands.Create;

public class CreateServidorCommandHandler : IRequestHandler<CreateServidorCommand, Guid>
{
    private readonly AppDbContext _context;

    public CreateServidorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateServidorCommand request, CancellationToken cancellationToken)
    {
        var servidor = new Servidor(
            nome: request.Nome,
            orgaoId: request.OrgaoId,
            lotacaoId: request.LotacaoId,
            telefone: request.Telefone,
            email: request.Email,
            sala: request.Sala
        );

        _context.Servidores.Add(servidor);
        await _context.SaveChangesAsync(cancellationToken);

        return servidor.Id;
    }
}
