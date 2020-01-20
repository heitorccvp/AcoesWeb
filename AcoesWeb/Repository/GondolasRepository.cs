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
	public class GondolasRepository : IGondolasRepository
	{
		IConfiguration _configuration;
		public GondolasRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Gondolas gondola)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"insert into Gondolas
								(
							      nome
								, id_farmacia
								, id_posicao
								, altura
								, largura
								)
								values
								(
								  @nome
								, @id_farmacia
								, @id_posicao
								, @altura
								, @largura
								)
								; SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, gondola);
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
					var query = "DELETE FROM Gondolas WHERE id =" + id;
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
		public int Edit(Gondolas gondola)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"UPDATE Gondolas 
									SET Nome = @Nome
									,id_farmacia = @id_farmacia
									,id_posicao = @id_posicao
									,altura = @altura
									,largura = @largura
								WHERE id = " + gondola.Id;

					count = con.Execute(query, gondola);
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
		public Gondolas Get(int id)
		{
			var connectionString = this.GetConnection();
			Gondolas gondola = new Gondolas();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Gondolas WHERE id =" + id;
					gondola = con.Query<Gondolas>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return gondola;
			}
		}
		public List<GondolasView> GetGondolas()
		{
			var connectionString = this.GetConnection();
			List<GondolasView> gondolas = new List<GondolasView>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"select 
									 Gondolas.id
									,Gondolas.Nome
									,Farmacias.nome as Farmacia
									,posicao.nome as Posicao
									,Gondolas.altura
									,Gondolas.largura 
								from Gondolas 
									LEFT JOIN Farmacias ON Farmacias.id = Gondolas.id_farmacia
									LEFT JOIN posicao ON posicao.id = Gondolas.id_posicao";
					gondolas = con.Query<GondolasView>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return gondolas;
			}
		}
	}
}
