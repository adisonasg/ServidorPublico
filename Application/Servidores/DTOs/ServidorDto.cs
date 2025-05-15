namespace ServidorPublico.Application.Servidores.DTOs
{
    public class ServidorDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Sala { get; set; }
        public string Orgao { get; set; } = null!;
        public string Lotacao { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}
