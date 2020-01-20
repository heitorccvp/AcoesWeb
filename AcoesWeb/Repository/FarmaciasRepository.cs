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
	public class FarmaciasRepository : IFarmaciasRepository
	{
		IConfiguration _configuration;
		public FarmaciasRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GetConnection()
		{
			var connection = _configuration.GetSection("ConnectionStrings").GetSection("TesteConnection").Value;
			return connection;
		}
		public int Add(Farmacias associado)
		{
			var connectionString = this.GetConnection();
			int count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"insert into Farmacias
								(
								id_associado
								, nome
								, local
								)
								values
								(
								 @id_associado
								, @nome
								, @local
								); SELECT CAST(SCOPE_IDENTITY() as INT); ";

					count = con.Execute(query, associado);
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
					var query = "DELETE FROM Farmacias WHERE id =" + id;
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
		public int Edit(Farmacias associado)
		{
			var connectionString = this.GetConnection();
			var count = 0;
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Farmacias SET Nome = @Nome, Local = @Local, id_associado = @id_associado WHERE id = " + associado.Id;

					count = con.Execute(query, associado);
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
		public Farmacias Get(int id)
		{
			var connectionString = this.GetConnection();
			Farmacias associado = new Farmacias();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Farmacias WHERE id =" + id;
					associado = con.Query<Farmacias>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return associado;
			}
		}
		public List<FarmaciasView> GetFarmacia()
		{
			var connectionString = this.GetConnection();
			List<FarmaciasView> farmacias = new List<FarmaciasView>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = @"SELECT 
									Farmacias.id,
									Farmacias.nome,
									Farmacias.local,
									associados.nome as associado
								 FROM Farmacias
									LEFT JOIN associados ON associados.id = farmacias.id_associado
									";

					farmacias = con.Query<FarmaciasView>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return farmacias;
			}
		}
	}
}
