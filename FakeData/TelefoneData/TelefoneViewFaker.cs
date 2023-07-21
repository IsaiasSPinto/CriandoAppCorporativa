using Bogus;
using Core.ModelViews.Telefone;

namespace CL.FakeData.TelefoneData;
public class TelefoneViewFaker : Faker<TelefoneView>
{
		public TelefoneViewFaker()
		{
				RuleFor(p => p.Id, f => f.Random.Number(0, 99999));
				RuleFor(p => p.Numero, f => f.Person.Phone);
		}
}
