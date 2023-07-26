using Bogus;
using Core.Domain;

namespace CL.FakeData.FuncoesData;
public class FuncaoFaker : Faker<Funcao>
{
		public FuncaoFaker()
		{
				var id = new Faker().Random.Number(0, 99999);
				RuleFor(x => x.Id, f => id);
				RuleFor(x => x.Descricao, f => f.Name.JobType());
		}
}
