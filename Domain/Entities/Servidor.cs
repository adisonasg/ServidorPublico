namespace ServidorPublico.Domain.Entities;

public class Servidor
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;

    // Relacionamento com Orgao (chave primária é int)
    public int OrgaoId { get; set; }
    public Orgao Orgao { get; set; } = null!;

    // Relacionamento com Lotacao (chave primária é Guid)
    public Guid LotacaoId { get; set; }
    public Lotacao Lotacao { get; set; } = null!;
}
