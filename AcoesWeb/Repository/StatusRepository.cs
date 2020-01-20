using AcoesWeb.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AcoesWeb.Repository
{
	public class StatusRepository : IStatusRepository
	{
		IConfiguration _configuration;
		public StatusRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Status status)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "INSERT INTO Status(Nome) VALUES(@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, status);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public int Delete(int id)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "DELETE FROM Status WHERE id =" + id;
					count = con.Execute(query);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public int Edit(Status status)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Status SET Nome = @Nome WHERE id = " + status.Id;

					count = con.Execute(query, status);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return count;
			}
		}
		public Status Get(int id)
		{
			var connectionString = this.GetConnection();
			Status status = new Status();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Status WHERE id =" + id;
					status = con.Query<Status>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return status;
			}
		}
		public List<Status> GetStatus()
		{
			var connectionString = this.GetConnection();
			List<Status> status = new List<Status>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Status";
					status = con.Query<Status>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return status;
			}
		}
	}
}
