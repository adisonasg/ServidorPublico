using MediatR;

namespace ServidorPublico.Application.Servidores.Commands.Create;

public class CreateServidorCommand : IRequest<Guid>
{
    public string Nome { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public int OrgaoId { get; set; } // ← Corrigido de Guid para int

    public Guid LotacaoId { get; set; }
    public string? Sala { get; set; }
}
