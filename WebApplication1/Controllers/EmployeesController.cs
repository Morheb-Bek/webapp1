using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Threading.Tasks.Dataflow;
using WebApplication1.Services;
using System.Data;

namespace WebApplication1.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly IStore store;

		public EmployeesController(IStore store)
		{
			this.store = store;
		}

		[Route("api/[controller]")]
		[HttpPost]
		public ActionResult<SubmissionResponse> SaveEmployee([FromBody] Employee employee)
		{
			if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
			{
				return BadRequest(new SubmissionResponse
				{
					Success = false,
					ErrorCode = "invalid"
				});
			}

			employee.Id = Guid.NewGuid();

			var submissionResult = store.SaveEmployee(employee);

			if (!submissionResult.Success)
			{
				return BadRequest(submissionResult);
			}

			return Ok(submissionResult);
		}

		[HttpGet()]
		[Route("api/[controller]/{name}")]
		public ActionResult<string> Get(string name)
		{
			List<Employee>  ListofEmployees = store.GetEmployees(name);
			return Ok(ListofEmployees);

		}
	}
}
