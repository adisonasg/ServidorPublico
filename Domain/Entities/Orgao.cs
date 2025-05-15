namespace ServidorPublico.Domain.Entities;

public class Orgao
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;

    public ICollection<Servidor> Servidores { get; set; } = new List<Servidor>();
}
