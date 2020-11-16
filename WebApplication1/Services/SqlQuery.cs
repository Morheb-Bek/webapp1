using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Services
{
	public class SqlQuery
	{
		string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\morhe\Documents\EmpDB.mdf;Integrated Security=True;Connect Timeout=30";

		public SubmissionResponse PostQuery(string query, SqlParameter[] parameters)
		{
			using (var connection = new SqlConnection(connectionString))
			{
				using (var cmd = new SqlCommand(query, connection))
				{
					if (parameters !=null && parameters.Length!=0)
					{
						cmd.Parameters.AddRange(parameters);
					}

					connection.Open();

					cmd.ExecuteNonQuery();

					return new SubmissionResponse { Success = true };
				}

			}
		}
	}
}
