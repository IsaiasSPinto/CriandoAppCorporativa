using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class MedicoRepository : IMedicoRepository
{
		private readonly DatabaseContext _context;
		public MedicoRepository(DatabaseContext context)
		{
				_context = context;
		}

		public async Task<IEnumerable<Medico>> GetMedicosAsync()
		{
				return await _context.Medicos
						.Include(x => x.Especialidades)
						.AsNoTracking()
						.ToListAsync();
		}
		public async Task<Medico> GetMedicoAsync(int id)
		{
				return await _context.Medicos
						.Include(x => x.Especialidades)
						.SingleOrDefaultAsync(x => x.Id == id);
		}
		public async Task<Medico> InsertMedicoAsync(Medico medico)
		{
				await InsertMedicoEspecilidades(medico);
				await _context.Medicos.AddAsync(medico);
				await _context.SaveChangesAsync();
				return medico;
		}

		private async Task InsertMedicoEspecilidades(Medico medico)
		{
				var especialidadesConsultadas = new List<Especialidade>();
				foreach (var especialidade in medico.Especialidades)
				{
						var especialidadeConsultada = await _context.Especialidades.FindAsync(especialidade.Id);
						especialidadesConsultadas.Add(especialidadeConsultada);
				}
				medico.Especialidades = especialidadesConsultadas;
		}

		public async Task<Medico> UpdateMedicoAsync(Medico medico)
		{
				var medicoConsultado = await _context.Medicos.Include(x => x.Especialidades).SingleOrDefaultAsync(x => x.Id == medico.Id);

				if (medicoConsultado == null)
				{
						return null;
				}

				_context.Entry(medicoConsultado).CurrentValues.SetValues(medico);

				await UpdateMedicoEspecialidades(medico, medicoConsultado);

				await _context.SaveChangesAsync();

				return medicoConsultado;
		}

		private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
		{
				medicoConsultado.Especialidades.Clear();

				foreach (var especialidade in medico.Especialidades)
				{
						var especialidadeConsultada = await _context.Especialidades.FindAsync(especialidade.Id);
						medicoConsultado.Especialidades.Add(especialidadeConsultada);
				}
		}

		public async Task DeleteMedicoAsync(int id)
		{
				var medicoConsultado = await _context.Medicos.FindAsync(id);

				if (medicoConsultado == null) return;

				_context.Medicos.Remove(medicoConsultado);
				await _context.SaveChangesAsync();
		}

}
