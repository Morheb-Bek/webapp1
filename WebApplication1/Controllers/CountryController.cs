using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	
	[ApiController]
	public class CountryController : Controller
	{
		private readonly IStore store;
		public CountryController()
		{
			this.store = new SqlStore();
		}
		[Route("api/[controller]")]
		[HttpPost]
		public ActionResult<SubmissionResponse> SaveCountry([FromBody] Country country)
		{
			if (country == null || string.IsNullOrWhiteSpace(country.Name))
			{
				return BadRequest(new SubmissionResponse
				{
					Success = false,
					ErrorCode = "invalid country"
				});
			}

			country.Id = Guid.NewGuid();

			var submissionResult = store.SaveCountry(country);

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
			var submissionResult = store.GetEmployee(name);
			return Ok(submissionResult);
			
		}
	}
}
