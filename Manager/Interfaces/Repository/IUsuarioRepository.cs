using Core.Domain;

namespace Manager.Interfaces.Repository;
public interface IUsuarioRepository
{
		public Task<IEnumerable<Usuario>> GetUsuariosAsync();
		public Task<Usuario> GetUsuarioAsync(string login);
		public Task<Usuario> InsertUsuarioAsync(Usuario usuario);
		public Task<Usuario> UpdateUsuarioAsync(Usuario usuario);
		public Task DeleteUsuarioAsync(string login);
}
