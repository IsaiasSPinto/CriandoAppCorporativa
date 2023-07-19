using Core.ModelViews.Medico;
using FluentValidation;
using Manager.Interfaces.Repository;

namespace Manager.Validator;
public class AlteraMedicoValidator : AbstractValidator<AlteraMedico> 
{
		public AlteraMedicoValidator(IEspecialidadeRepository repository)
		{
				RuleFor(x => x.Id).NotEmpty().NotEmpty().GreaterThan(0);
				Include(new NovoMedicoValidator(repository));
		}
}
