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
        // Validações básicas
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ArgumentException("O nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new ArgumentException("O email é obrigatório.");

        if (request.OrgaoId == Guid.Empty)
            throw new ArgumentException("O ID do órgão é obrigatório.");

        if (request.LotacaoId == Guid.Empty)
            throw new ArgumentException("O ID da lotação é obrigatório.");

        var servidor = new Servidor(
            nome: request.Nome,
            telefone: request.Telefone,
            email: request.Email,
            sala: request.Sala,
            orgaoId: request.OrgaoId,
            lotacaoId: request.LotacaoId
        )
        {
            Id = Guid.NewGuid()
        };

        await _context.Servidores.AddAsync(servidor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return servidor.Id;
    }
}
