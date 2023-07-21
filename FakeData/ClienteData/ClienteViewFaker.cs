using Core.ModelViews.Cliente;
using Bogus;
using Core.Domain.Enum;
using Bogus.Extensions.Brazil;
using CL.FakeData.TelefoneData;
using CL.FakeData.EnderecoData;

namespace CL.FakeData.ClienteData;

public class ClienteViewFaker: Faker<ClienteView>
{
		public ClienteViewFaker()
		{
				var id = new Faker().Random.Number(0, 99999);
				RuleFor(x => x.Id , f => id);
				RuleFor(x => x.Nome, f => f.Person.FullName);
				RuleFor(x => x.Sexo, f => f.PickRandom<SexoView>());
				RuleFor(x => x.Documento, f => f.Person.Cpf());
				RuleFor(x => x.Criacao, f => f.Date.Past());
				RuleFor(x => x.UltimaAtualizacao, f => f.Date.Past());
				RuleFor(x => x.DataNascimento, f => f.Date.Past(18));
				RuleFor(x => x.Telefones, f => new TelefoneViewFaker().Generate(3));
				RuleFor(x => x.Endereco, f => new EnderecoViewFaker().Generate());
		}
}
