namespace Core.ModelViews.Endereco;
public class NovoEndereco
{
    /// <example>49000000</example>
    public int CEP { get; set; }
    /// <example>RS</example>
    public string Estado { get; set; }
    /// <example>Caxias do Sul</example>
    public string Cidade { get; set; }
    /// <example>Rua A</example>
    public string Logradouro { get; set; }
    /// <example>168</example>
    public string Numero { get; set; }
    /// <example>Casa</example>
    public string Complemento { get; set; }
}