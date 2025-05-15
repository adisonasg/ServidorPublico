using MediatR;
using Microsoft.EntityFrameworkCore;
using ServidorPublico.Infrastructure.Data;
using ServidorPublico.Application.Servidores.DTOs;
using ServidorPublico.Application.Queries.Servidor;
using ServidorPublico.Application.Servidores.Queries;

namespace ServidorPublico.Application.Handlers.Servidores;

public class GetServidorByIdHandler : IRequestHandler<GetServidorByIdQuery, ServidorDto?>
{
    private readonly AppDbContext _context;

    public GetServidorByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServidorDto?> Handle(GetServidorByIdQuery request, CancellationToken cancellationToken)
    {
        var servidor = await _context.Servidores
            .Include(s => s.Orgao)
            .Include(s => s.Lotacao)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (servidor is null)
            return null;

        return new ServidorDto
        {
            Id = servidor.Id,
            Nome = servidor.Nome,
            Telefone = servidor.Telefone,
            Email = servidor.Email,
            Sala = servidor.Sala,
            Orgao = servidor.Orgao?.Nome ?? "",
            Lotacao = servidor.Lotacao?.Nome ?? "",
            Ativo = servidor.Ativo
        };
    }
}
