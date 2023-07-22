using Bogus;
using Core.ModelViews.Telefone;

namespace CL.FakeData.TelefoneData;

public class NovoTelefoneViewFaker : Faker<NovoTelefone>
{
		public NovoTelefoneViewFaker()
		{
				RuleFor(p => p.Numero, f => f.Person.Phone);
		}
}
