using Bogus;
using Core.ModelViews.Usuario;

namespace CL.FakeData.UsuarioData;
public class UsuarioViewFaker : Faker<UsuarioView>
{
		public UsuarioViewFaker()
		{
				RuleFor(x => x.Login, f => f.Person.Email);
				//RuleFor(x => x.Funcoes, f => f.Person.Email);
		}
}
