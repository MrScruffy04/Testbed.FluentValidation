namespace Testbed.FluentValidation
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using global::FluentValidation;

	class Program
	{
		#region Main Program Loop

		private static ManualResetEvent _quitEvent = new ManualResetEvent(false);

		[STAThread]
		private static void Main(string[] args)
		{
			Console.CancelKeyPress += (sender, e) =>
			{
				_quitEvent.Set();
				e.Cancel = true;
			};

			try
			{
				#region Setup
				#endregion


				ProgramBody();

				//  One of the following should be commented out. The other should be uncommented.

				//_quitEvent.WaitOne();  //  Wait on UI thread for Ctrl + C

				Console.ReadKey(true);  //  Wait for any character input
			}
			finally
			{
				#region Tear down
				#endregion
			}
		}

		#endregion





		private static void ProgramBody()
		{
			var personValidator = new PersonValidator();

			var personModel = new PersonModel
			{
				EmployeeId = 17,
				Name = "Billy Test",
				DateOfBirth = DateTime.Parse("1982-01-08T08:27:14Z"),
			};

			Validate(personValidator, new PersonModel(), "Billy");
		}

		private static bool Validate<TModel>(AbstractValidator<TModel> validator, TModel model, string id)
		{
			var result = validator.Validate(model);

			Console.WriteLine("{0} ({1}):\n================", id, typeof(TModel).Name);

			if (result.IsValid)
			{
				Console.WriteLine("\tValid!");

			}
			else
			{
				foreach (var error in result.Errors)
				{
					Console.WriteLine("\t{0} = {1}", error.PropertyName, error.AttemptedValue);
					Console.WriteLine("\t{0}", error.ErrorMessage);
					Console.WriteLine();
				}
			}

			return result.IsValid;
		}

	}

}
