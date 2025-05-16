namespace ServidorPublico.Domain.Entities;

public class Servidor
{
    public Guid Id { get; set; } // Alterado de int para Guid
    public string Nome { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Sala { get; set; } = null!;
    public bool Ativo { get; set; } = true;

    // Relacionamento com Orgao (chave primária continua sendo int)
    public int OrgaoId { get; set; }
    public Orgao Orgao { get; set; } = null!;

    // Relacionamento com Lotacao (chave primária é Guid)
    public Guid LotacaoId { get; set; }
    public Lotacao Lotacao { get; set; } = null!;

    public Servidor(string nome, string telefone, string email, string sala, int orgaoId, Guid lotacaoId)
    {
        Id = Guid.NewGuid(); // Gerando novo Guid
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Sala = sala;
        OrgaoId = orgaoId;
        LotacaoId = lotacaoId;
        Ativo = true;
    }

    public void Atualizar(string nome, string telefone, string email, string sala, int orgaoId, Guid lotacaoId)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
        Sala = sala;
        OrgaoId = orgaoId;
        LotacaoId = lotacaoId;
    }

    public void Inativar()
    {
        Ativo = false;
    }
}
