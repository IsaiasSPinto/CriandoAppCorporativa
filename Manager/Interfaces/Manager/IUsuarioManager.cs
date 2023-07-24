using Core.Domain;
using Core.ModelViews.Usuario;

namespace Manager.Interfaces.Manager;

public interface IUsuarioManager 
{
		public Task<IEnumerable<UsuarioView>> GetUsuariosAsync();
		public Task<UsuarioView> GetUsuarioAsync(string login);
		public Task<UsuarioView> InsertUsuarioAsync(Usuario usuario);
		public Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario);
		public Task<bool> ValidaSenhaAsync(Usuario usuario);
}
