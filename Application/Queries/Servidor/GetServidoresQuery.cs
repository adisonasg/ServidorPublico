using MediatR;

namespace ServidorPublico.Application.Servidores.Queries;

public class GetServidoresQuery : IRequest<List<ServidorDto>>
{
    public string? Nome { get; set; }
    public Guid? OrgaoId { get; set; }
    public Guid? LotacaoId { get; set; }
}
