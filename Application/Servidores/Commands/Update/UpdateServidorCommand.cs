using MediatR;

namespace ServidorPublico.Application.Servidores.Commands.Update;

public class UpdateServidorCommand : IRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public Guid OrgaoId { get; set; }
    public Guid LotacaoId { get; set; }
    public string? Sala { get; set; }
}
