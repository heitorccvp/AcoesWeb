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
	public class AprovadoresRepository : IAprovadoresRepository
	{
		IConfiguration _configuration;
		public AprovadoresRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Aprovadores aprovador)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "INSERT INTO Aprovadores(Nome) VALUES(@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, aprovador);
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
					var query = "DELETE FROM Aprovadores WHERE id =" + id;
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
		public int Edit(Aprovadores aprovador)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Aprovadores SET Nome = @Nome WHERE id = " + aprovador.Id;

					count = con.Execute(query, aprovador);
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
		public Aprovadores Get(int id)
		{
			var connectionString = this.GetConnection();
			Aprovadores aprovador = new Aprovadores();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Aprovadores WHERE id =" + id;
					aprovador = con.Query<Aprovadores>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return aprovador;
			}
		}
		public List<Aprovadores> GetAprovadores()
		{
			var connectionString = this.GetConnection();
			List<Aprovadores> aprovadores = new List<Aprovadores>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Aprovadores";
					aprovadores = con.Query<Aprovadores>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return aprovadores;
			}
		}
	}
}
