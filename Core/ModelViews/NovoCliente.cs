namespace Core.ModelViews;
/// <summary>
/// Objeto utilizado para inserção de um novo cliente
/// </summary>
public class NovoCliente
{
    /// <summary>
    /// Nome do cliente
    /// </summary>
    /// <example>João do caminhão</example>
    public string Nome { get; set; }
    /// <summary>
    /// Sexo do cliente
    /// </summary>
    /// <example>M</example>
    public char Sexo { get; set; }
    /// <summary>
    /// Telefone do cliente
    /// </summary>
    /// <example>54994533587</example>
    public string Telefone { get; set; }
    /// <summary>
    /// Documento do cliente: CNH,CPF,RG
    /// </summary>
    /// <example>99999999999</example>
    public string Documento { get; set; }
    /// <summary>
    /// Data de nascimento do cliente
    /// </summary>
    /// <example>1980-05-01</example>
    public DateTime DataNascimento { get; set; }
}
