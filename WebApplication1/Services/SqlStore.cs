﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;
using System.Data.SqlClient;
namespace WebApplication1.Services
{
	public class SqlStore : IStore
	{
		private readonly string connectionString;
		private readonly SqlQuery sqlQuery;
		public SqlStore(SqlQuery sqlQuery)         
		{
			this.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\morhe\Documents\EmpDB.mdf;Integrated Security=True;Connect Timeout=30";
			this.sqlQuery = sqlQuery;
		}

	public SubmissionResponse SaveEmployee(Employee employee)
	{
			//using (var connection = new SqlConnection(connectionString))
			//{
			//	using (var cmd = new SqlCommand("INSERT INTO Employee (Id , Name, CountryId) Values (@Id, @Name, @CountryId) ", connection))
			//	{
			//		cmd.Parameters.AddWithValue("@Id", employee.Id);
			//		cmd.Parameters.AddWithValue("@Name", employee.Name);
			//		cmd.Parameters.AddWithValue("@CountryId", employee.CountryId);
			//		connection.Open();

			//		cmd.ExecuteNonQuery();

			//		return new SubmissionResponse { Success = true };
			//	}
			//}
			return sqlQuery.PostQuery("INSERT INTO Employee (Id , Name, CountryId) Values (@Id, @Name, @CountryId) ",
				new[] {
					new SqlParameter ("@Id", employee.Id), 
					new SqlParameter ("@Name", employee.Name), 
					new SqlParameter ("@CountryId", employee.CountryId) 
				});
	}
	public IEnumerable<Employee> GetEmployees(string empName)
	{
		List<Employee> listOfEmployees = new List<Employee>();

		using (var connection = new SqlConnection(connectionString))
		{
			connection.Open();
			using (SqlCommand command = new SqlCommand("SELECT * FROM Employee WHERE Name = @name", connection))
			{
				command.Parameters.AddWithValue("@Name", empName);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Employee employee = new Employee();

						employee.Id = reader.GetGuid(reader.GetOrdinal("Id"));
						employee.Name = reader.GetString(reader.GetOrdinal("Name"));
						employee.CountryId = reader.GetGuid(reader.GetOrdinal("CountryId"));

						listOfEmployees.Add(employee);

					}
					return (listOfEmployees);
				}
			}
		}
	}
	public SubmissionResponse SaveCountry(Country country)
	{
		using (var connection = new SqlConnection(connectionString))
		{
			using (var cmd = new SqlCommand("INSERT INTO Country (Id , Name, Code) Values (@Id, @Name, @Code) ", connection))
			{
				cmd.Parameters.AddWithValue("@Id", country.Id);
				cmd.Parameters.AddWithValue("@Name", country.Name);
				cmd.Parameters.AddWithValue("@Code", country.Code);
				connection.Open();
				cmd.ExecuteNonQuery();
				return new SubmissionResponse { Success = true };
			}
		}
	}
}
}
