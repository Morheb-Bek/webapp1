using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class EmployeesController : Controller
				
	{
		[Route("api/[controller]")]
		[HttpPost]
		
		public ActionResult<SubmissionResponse> SaveEmployee ([ FromBody]Employees employees)
		{
			if (employees == null || string.IsNullOrWhiteSpace(employees.Name)) {

				return BadRequest(new SubmissionResponse
				{
					Success = false,
					ErrorCode = "invalid"
				});


				

			}
			return Ok(new SubmissionResponse
			{
				Success = true
			});
		}
		[HttpGet()]
		[Route("api/[controller]/{name}")]

		
		public ActionResult<string> Get()
		{
			return ("employees get");
		}
	}
}
