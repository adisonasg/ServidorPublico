using MediatR;
using ServidorPublico.Application.Servidores.DTOs;

namespace ServidorPublico.Application.Servidores.Queries
{
    public class GetServidorByIdQuery : IRequest<ServidorDto?>
    {
        public Guid Id { get; set; }

        public GetServidorByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
