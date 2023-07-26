using Bogus;
using CL.FakeData.FuncoesData;
using Core.Domain;

namespace CL.FakeData.UsuarioData;
public class UsuarioFaker : Faker<Usuario>
{
		public UsuarioFaker()
		{
				RuleFor(x => x.Login, f => f.Person.Email);
				RuleFor(x => x.Senha, f => f.Random.Word());
				RuleFor(x => x.Funcoes, f => new FuncaoFaker().Generate(3));
		}
}
