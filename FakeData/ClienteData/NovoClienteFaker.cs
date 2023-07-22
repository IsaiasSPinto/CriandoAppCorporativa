using Bogus;
using Core.ModelViews.Cliente;
using Bogus.Extensions.Brazil;
using CL.FakeData.EnderecoData;
using CL.FakeData.TelefoneData;

namespace CL.FakeData.ClienteData;
public class NovoClienteFaker : Faker<NovoCliente>
{
		public NovoClienteFaker()
		{
				RuleFor(x => x.Nome, f => f.Person.FullName);
				RuleFor(x => x.Sexo, f => f.PickRandom<SexoView>());
				RuleFor(x => x.Documento, f => f.Person.Cpf());
				RuleFor(x => x.DataNascimento, f => f.Date.Past(18));
				RuleFor(x => x.Telefones, f => new NovoTelefoneViewFaker().Generate(3));
				RuleFor(x => x.Endereco, f => new NovoEnderecoFaker().Generate());
		}
}
