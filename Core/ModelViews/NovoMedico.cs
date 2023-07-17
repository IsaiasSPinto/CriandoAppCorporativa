using Core.Domain;

namespace Core.ModelViews;

public class NovoMedico
{
    public string Nome { get; set; }
    public int CRM { get; set; }

    public ICollection<Especialidade> Especialidades { get; set; }
}
