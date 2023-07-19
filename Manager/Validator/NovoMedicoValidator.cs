using Core.Domain;
using Core.ModelViews.Medico;
using FluentValidation;
using Manager.Interfaces.Repository;

namespace Manager.Validator;
public class NovoMedicoValidator : AbstractValidator<NovoMedico>
{
		public NovoMedicoValidator(IEspecialidadeRepository repository)
		{
				RuleFor(x => x.Nome).NotEmpty().NotNull().MaximumLength(200);
				RuleFor(x => x.CRM).NotEmpty().NotNull().GreaterThan(0);
				RuleForEach(x => x.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repository));
		}
}
