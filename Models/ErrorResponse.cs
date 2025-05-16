using System.Text.Json.Serialization;

namespace ServidorPublico.API.Models;

/// <summary>
/// Representa um modelo padronizado de resposta de erro para a API.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Código de status HTTP da resposta.
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }

    /// <summary>
    /// Mensagem de erro amigável para o cliente.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
