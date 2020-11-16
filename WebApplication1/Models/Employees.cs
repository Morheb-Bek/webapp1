using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
	
	public class Employee
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid CountryId { get; set; }
	}

}
