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
	public class FornecedoresRepository : IFornecedoresRepository
	{
		IConfiguration _configuration;
		public FornecedoresRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Fornecedores fornecedor)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "INSERT INTO Fornecedores(Nome) VALUES(@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, fornecedor);
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
					var query = "DELETE FROM Fornecedores WHERE id =" + id;
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
		public int Edit(Fornecedores fornecedor)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Fornecedores SET Nome = @Nome WHERE id = " + fornecedor.Id;

					count = con.Execute(query, fornecedor);
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
		public Fornecedores Get(int id)
		{
			var connectionString = this.GetConnection();
			Fornecedores fornecedor = new Fornecedores();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Fornecedores WHERE id =" + id;
					fornecedor = con.Query<Fornecedores>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return fornecedor;
			}
		}
		public List<Fornecedores> GetFornecedores()
		{
			var connectionString = this.GetConnection();
			List<Fornecedores> fornecedor = new List<Fornecedores>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Fornecedores";
					fornecedor = con.Query<Fornecedores>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return fornecedor;
			}
		}
	}
}
