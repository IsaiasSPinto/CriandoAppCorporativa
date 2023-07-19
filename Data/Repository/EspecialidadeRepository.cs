using Data.Context;
using Manager.Interfaces.Repository;

namespace Data.Repository;
public class EspecialidadeRepository : IEspecialidadeRepository
{
		private readonly DatabaseContext _context;
		public EspecialidadeRepository(DatabaseContext context)
		{
			_context = context;
		}

		public async Task<bool> ExisteAsync(int id) => await _context.Especialidades.FindAsync(id) != null;
}
