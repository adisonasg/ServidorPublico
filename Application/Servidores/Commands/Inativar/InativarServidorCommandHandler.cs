using MediatR;
using Microsoft.EntityFrameworkCore;
using ServidorPublico.Infrastructure.Data;

namespace ServidorPublico.Application.Servidores.Commands.Inativar;

public class InativarServidorCommandHandler : IRequestHandler<InativarServidorCommand>
{
    private readonly AppDbContext _context;

    public InativarServidorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(InativarServidorCommand request, CancellationToken cancellationToken)
    {
        var servidor = await _context.Servidores
            .FirstOrDefaultAsync(s => s.Id == request.Id && s.Ativo, cancellationToken);

        if (servidor == null)
            throw new KeyNotFoundException("Servidor não encontrado ou já inativo.");

        servidor.Inativar();
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
