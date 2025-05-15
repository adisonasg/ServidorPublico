using MediatR;
using ServidorPublico.Application.Servidores.DTOs;

namespace ServidorPublico.Application.Queries.Servidor
{
    public class GetServidoresQuery : IRequest<List<ServidorDto>>
    {
        public string? Nome { get; set; }
        public Guid? OrgaoId { get; set; }
        public Guid? LotacaoId { get; set; }
    }
}
