namespace Testbed.FluentValidation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public class PersonModel
	{
		public long EmployeeId { get; set; }

		public string Name { get; set; }

		public DateTime DateOfBirth { get; set; }
	}
}
