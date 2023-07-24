using Core.Domain;
using Core.ModelViews.Usuario;
using Manager.Interfaces.Manager;

namespace Manager.Implementation;
public class UsuarioManager : IUsuarioManager
{
		public Task<UsuarioView> GetUsuarioAsync(string login)
		{
				throw new NotImplementedException();
		}

		public Task<IEnumerable<UsuarioView>> GetUsuariosAsync()
		{
				throw new NotImplementedException();
		}

		public Task<UsuarioView> InsertUsuarioAsync(Usuario usuario)
		{
				throw new NotImplementedException();
		}

		public Task<UsuarioView> UpdateUsuarioAsync(Usuario usuario)
		{
				throw new NotImplementedException();
		}

		public Task<bool> ValidaSenhaAsync(Usuario usuario)
		{
				throw new NotImplementedException();
		}
}
