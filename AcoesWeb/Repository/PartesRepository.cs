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
	public class PartesRepository : IPartesRepository
	{
		IConfiguration _configuration;
		public PartesRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Partes parte)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"insert into partes
								( nome
								, id_gondola
								, id_posicao
								, altura
								, largura
								)
								values
								( @nome
								, @id_gondola
								, @id_posicao
								, @altura
								, @largura
								); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, parte);
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
					var query = "DELETE FROM Partes WHERE id =" + id;
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
		public int Edit(Partes parte)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"update Partes
									set nome = @nome 
									, id_gondola = @id_gondola
									, id_posicao = @id_posicao
									, altura = @altura
									, largura = @largura WHERE id = " + parte.Id;

					count = con.Execute(query, parte);
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
		public Partes Get(int id)
		{
			var connectionString = this.GetConnection();
			Partes parte = new Partes();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Partes WHERE id =" + id;
					parte = con.Query<Partes>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return parte;
			}
		}
		public List<PartesView> GetPartes()
		{
			var connectionString = this.GetConnection();
			List<PartesView> partes = new List<PartesView>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"select 
									partes.id,
									partes.nome,
									gondolas.nome as Gondola,
									posicao.nome as Posicao,
									partes.altura,
									partes.largura
								from partes
									left join gondolas on gondolas.id = partes.id_gondola
									left join posicao on posicao.id = partes.id_posicao";
					partes = con.Query<PartesView>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return partes;
			}
		}
	}
}
