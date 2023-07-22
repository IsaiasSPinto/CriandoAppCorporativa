using Bogus;
using Core.Domain;
using Core.Domain.Enum;

namespace CL.FakeData.EnderecoData;
public class EnderecoFaker : Faker<Endereco>
{
		public EnderecoFaker(int clientId)
		{
				RuleFor(o => o.ClienteId, _ => clientId);
				RuleFor(p => p.Estado, f => f.PickRandom<Estado>());
				RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
				RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
				RuleFor(p => p.Cidade, f => f.Address.City());
				RuleFor(p => p.Logradouro, f => f.Address.StreetName());
				RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
		}
}
