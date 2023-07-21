using Core.ModelViews.Especialidade;
using FluentValidation;
using Manager.Interfaces.Repository;

namespace Manager.Validator;
public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
{
		private readonly IEspecialidadeRepository _repository;
		public ReferenciaEspecialidadeValidator(IEspecialidadeRepository repository)
		{
				_repository = repository;
				RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0)
						.Must(ExisteNaBase).WithMessage("Especialidade não cadastrada.");
		}

		private bool ExisteNaBase(int id)
		{
				return  _repository.ExisteAsync(id).Result;
		}
}
