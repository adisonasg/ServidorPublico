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
            telefone: request.Telefone,
            email: request.Email,
            sala: request.Sala,
            orgaoId: request.OrgaoId,
            lotacaoId: request.LotacaoId
        )
        {
            Id = Guid.NewGuid() // ID gerado aqui
        };

        await _context.Servidores.AddAsync(servidor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return servidor.Id;
    }
}
