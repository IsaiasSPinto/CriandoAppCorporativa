namespace Manager.Interfaces.Repository;

public interface IEspecialidadeRepository
{
		Task<bool> ExisteAsync(int id);
}
