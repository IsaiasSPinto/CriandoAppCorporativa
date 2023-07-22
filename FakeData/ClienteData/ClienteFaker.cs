using Bogus;
using CL.FakeData.EnderecoData;
using CL.FakeData.TelefoneData;
using Core.Domain;
using Core.Domain.Enum;
using Bogus.Extensions.Brazil;


namespace CL.FakeData.ClienteData;
public class ClienteFaker : Faker<Cliente>
{
		public ClienteFaker()
		{
				var id = new Faker().Random.Number(0, 99999);
				RuleFor(x => x.Id, f => id);
				RuleFor(x => x.Nome, f => f.Person.FullName);
				RuleFor(x => x.Sexo, f => f.PickRandom<Sexo>());
				RuleFor(x => x.Documento, f => f.Person.Cpf());
				RuleFor(x => x.Criacao, f => f.Date.Past());
				RuleFor(x => x.UltimaAtualizacao, f => f.Date.Past());
				RuleFor(x => x.DataNascimento, f => f.Date.Past(18));
				RuleFor(x => x.Telefones, f => new TelefoneFaker(id).Generate(3));
				RuleFor(x => x.Endereco, f => new EnderecoFaker(id).Generate());
		}
}
