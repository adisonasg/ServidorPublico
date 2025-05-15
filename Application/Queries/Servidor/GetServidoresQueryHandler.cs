using MediatR;
using Microsoft.EntityFrameworkCore;
using ServidorPublico.Infrastructure.Data;
using ServidorPublico.Application.Queries.Servidor;     // ✅ Importa GetServidoresQuery
using ServidorPublico.Application.Servidores.DTOs;     // ✅ Importa ServidorDto

namespace ServidorPublico.Application.Servidores.Queries;

public class GetServidoresQueryHandler : IRequestHandler<GetServidoresQuery, List<ServidorDto>>
{
    private readonly AppDbContext _context;

    public GetServidoresQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ServidorDto>> Handle(GetServidoresQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Servidores
            .Where(s => s.Ativo)
            .AsQueryable();

        // Estes campos não existem no GetServidoresQuery:
        // request.Nome, request.OrgaoId, request.LotacaoId
        // Isso vai gerar erro se não forem definidos no modelo.
        // Remova-os ou adicione-os ao GetServidoresQuery

        return await query
            .Select(s => new ServidorDto
            {
                Id = s.Id,
                Nome = s.Nome,
                Telefone = s.Telefone,
                Email = s.Email,
                Orgao = s.Orgao.Nome,     // Se quiser usar OrgaoId, mude aqui também
                Lotacao = s.Lotacao.Nome, // Idem acima
                Sala = s.Sala,
                Ativo = s.Ativo
            })
            .ToListAsync(cancellationToken);
    }
}
