
using Bogus;
using Core.Domain;

namespace CL.FakeData.TelefoneData;
public class TelefoneFaker : Faker<Telefone>
{
		public TelefoneFaker(int clienteId)
		{
				RuleFor(o => o.ClienteId, _ => clienteId);
				RuleFor(p => p.Numero, f => f.Person.Phone);
		}
}
