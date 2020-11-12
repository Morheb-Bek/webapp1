using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Services
{
	public interface IStore
	{
		SubmissionResponse SaveEmployee(Employee employee);
		SubmissionResponse SaveCountry(Country country);
		List<Employee> GetEmployee(string empName);
		

	}
}
