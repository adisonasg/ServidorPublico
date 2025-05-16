using MediatR;
using Microsoft.EntityFrameworkCore;
using ServidorPublico.Infrastructure.Data;

namespace ServidorPublico.Application.Servidores.Commands.Update;

public class UpdateServidorCommandHandler : IRequestHandler<UpdateServidorCommand>
{
    private readonly AppDbContext _context;

    public UpdateServidorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateServidorCommand request, CancellationToken cancellationToken)
    {
        var servidor = await _context.Servidores
            .FirstOrDefaultAsync(s => s.Id == request.Id && s.Ativo, cancellationToken);

        if (servidor == null)
            throw new KeyNotFoundException("Servidor não encontrado.");

        servidor.Atualizar(
            request.Nome,
            request.Telefone,
            request.Email,
            request.Sala,
            request.OrgaoId,
            request.LotacaoId
        );

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
