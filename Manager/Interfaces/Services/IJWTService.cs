using Core.Domain;

namespace Manager.Interfaces.Services;
public interface IJWTService
{
		string GerarToken(Usuario usuario);
}
