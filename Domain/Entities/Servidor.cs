namespace ServidorPublico.Domain.Entities;

public class Servidor
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public Guid OrgaoId { get; set; }

    public Guid LotacaoId { get; set; }

    public string? Sala { get; set; }

    public bool Ativo { get; set; } = true;

    // Construtor usado pelo EF Core
    protected Servidor() { }

    // Construtor de domínio
    public Servidor(string nome, Guid orgaoId, Guid lotacaoId, string? telefone = null, string? email = null, string? sala = null)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        OrgaoId = orgaoId;
        LotacaoId = lotacaoId;
        Telefone = telefone;
        Email = email;
        Sala = sala;
        Ativo = true;
    }

    public void Atualizar(string nome, Guid orgaoId, Guid lotacaoId, string? telefone, string? email, string? sala)
    {
        Nome = nome;
        OrgaoId = orgaoId;
        LotacaoId = lotacaoId;
        Telefone = telefone;
        Email = email;
        Sala = sala;
    }

    public void Inativar()
    {
        Ativo = false;
    }
}
