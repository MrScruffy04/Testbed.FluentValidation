namespace Testbed.FluentValidation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using global::FluentValidation;

	public class PersonValidator : AbstractValidator<PersonModel>
	{
		public PersonValidator()
		{
			//CascadeMode = FluentValidation.CascadeMode.StopOnFirstFailure;

			RuleFor(x => x.EmployeeId)
				.NotEmpty();

			RuleFor(x => x.Name);
		}
	}
}
