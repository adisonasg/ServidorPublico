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
        var servidor = new Servidor
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Telefone = request.Telefone,
            Email = request.Email,
            OrgaoId = request.OrgaoId,
            LotacaoId = request.LotacaoId,
            Sala = request.Sala,
            Ativo = true
        };

        _context.Servidores.Add(servidor);
        await _context.SaveChangesAsync(cancellationToken);

        return servidor.Id;
    }
}
