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
	public class PosicaoRepository : IPosicaoRepository
	{
		IConfiguration _configuration;
		public PosicaoRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Posicao posicao)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "INSERT INTO Posicao(Nome) VALUES(@Nome); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, posicao);
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
					var query = "DELETE FROM Posicao WHERE id =" + id;
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
		public int Edit(Posicao posicao)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Posicao SET Nome = @Nome WHERE id = " + posicao.Id;

					count = con.Execute(query, posicao);
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
		public Posicao Get(int id)
		{
			var connectionString = this.GetConnection();
			Posicao posicao = new Posicao();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Posicao WHERE id =" + id;
					posicao = con.Query<Posicao>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return posicao;
			}
		}
		public List<Posicao> GetPosicao()
		{
			var connectionString = this.GetConnection();
			List<Posicao> posicao = new List<Posicao>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Posicao";
					posicao = con.Query<Posicao>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return posicao;
			}
		}
	}
}
